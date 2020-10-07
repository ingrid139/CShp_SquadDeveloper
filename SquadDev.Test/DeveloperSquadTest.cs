using SquadDev.Exceptions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SquadDev.Test
{
    public class DeveloperSquadTest
    {
        private static ISquadManager NovaInstancia()
        {
            return new SquadManager();
        }

        private static ISquadManager AdicionarSquad(long squadId)
        {
            var manager = NovaInstancia();

            manager.AddSquad(squadId, $"Squad {squadId}");
            return manager;
        }

        private static ISquadManager AdicionarDesenvolvedorEmSquad(long squadId, long developerId)
        {
            var manager = AdicionarSquad(squadId);

            manager.AddDev(developerId, squadId, $"Desenvolvedor {developerId}");
            return manager;
        }

        private static ISquadManager AdicionarDesenvolvedoresEmSquad(long squadId, IEnumerable<long> developersIds)
        {
            var manager = AdicionarSquad(squadId);

            developersIds.ToList().ForEach(playerId => 
            { 
                manager.AddDev(playerId, squadId, $"Desenvolvedor {playerId}");
            });

            return manager;
        }

        [Fact]
        public void Nao_Devera_Achar_Developer()
        {
            //arranje
            long wrongDevId = 2;
            //act - método sob teste
            var manager = NovaInstancia();
            //assert
            Assert.Throws<DevNotFoundException>(() => manager.GetDevName(wrongDevId));
        }

        [Fact]
        public void Nao_Devera_Achar_Squad()
        {
            //arranje
            long wrongSquadId = 2;
            //act
            var manager = NovaInstancia();
            //assert
            Assert.Throws<SquadNotFoundException>(() => manager.GetSquadDevs(wrongSquadId));
        }

        [Fact]
        public void Adicionar_e_Achar_Squad()
        {
            //arranje
            long squadId = 1;
            long wrongSquadId = 2;

            //act
            var manager = AdicionarSquad(squadId);

            //assert
            Assert.Throws<SquadNotFoundException>(() => manager.GetSquadDevs(wrongSquadId));
            Assert.Equal($"Squad {squadId}", manager.GetSquadName(squadId));
        }

        [Fact]
        public void Adicionar_e_Achar_Desenvolvedor()
        {
            //arranje
            long squadId = 1;
            long devId = 1;
            long wrongSquadId = 2;

            //act
            var manager = AdicionarDesenvolvedorEmSquad(squadId, devId);

            //assert
            Assert.Throws<SquadNotFoundException>(() => manager.GetSquadDevs(wrongSquadId));
            Assert.Equal($"Desenvolvedor {devId}", manager.GetDevName(devId));
        }

        [Fact]
        public void Adicionar_Squad_Duplicado()
        {
            //arranje
            long squadId = 1;

            //act
            var manager = AdicionarSquad(squadId);

            //assert
            Assert.Throws<UniqueIdentifierException>(() => manager.AddSquad(squadId, $"Squad {squadId}"));
        }

        [Fact]
        public void Adicionar_Developer_Duplicado()
        {
            //arranje
            long squadId = 1;
            long devId = 1;

            //act
            var manager = AdicionarDesenvolvedorEmSquad(squadId, devId);

            //assert
            Assert.Throws<UniqueIdentifierException>(() => manager.AddDev(devId, squadId, $"Desenvolvedor {devId}"));
        }

        [Fact]
        public void Nao_Devera_Achar_Tech_Leader()
        {
            long squadId = 1;
            long devId = 1;

            var manager = AdicionarDesenvolvedorEmSquad(squadId, devId);
            Assert.Throws<TechLeadNotFoundException>(() => manager.GetSquadTechLeader(squadId));
        }

        [Fact]
        public void Adicionar_e_Achar_Tech_Leader()
        {
            //arranje
            long squadId = 1;
            long devId = 1;
            long techLeaderId = 1;
            
            //act
            var manager = AdicionarDesenvolvedorEmSquad(squadId, devId);

            //assert
            Assert.Throws<TechLeadNotFoundException>(() => manager.GetSquadTechLeader(squadId));

            manager.SetTechLeader(techLeaderId);
            Assert.Equal(techLeaderId, manager.GetSquadTechLeader(squadId));
        }

        [Fact]
        public void Devera_garantir_Lista_Devs_Ordenada()
        {
            //arranje
            long squadId = 1;
            var devsIds = new List<long>() { 15, 2, 33, 4, 13 };

            //act
            var manager = AdicionarDesenvolvedoresEmSquad(squadId, devsIds);
            devsIds.Sort();

            //assert
            Assert.Equal(devsIds, manager.GetSquadDevs(squadId));
        }

        [Theory]
        [InlineData("15; 2; 33; 4; 13")]
        public void Devera_garantir_Lista_Devs_Ordenada_Args(string devs)
        {
            //arranje
            long squadId = 1;
            var devsIds = devs.Split(';').Select(x => long.Parse(x)).ToList();

            //act
            var manager = AdicionarDesenvolvedoresEmSquad(squadId, devsIds);
            //ordenar lista
            devsIds.Sort();

            //assert
            Assert.Equal(devsIds, manager.GetSquadDevs(squadId));
        }
    }
}
