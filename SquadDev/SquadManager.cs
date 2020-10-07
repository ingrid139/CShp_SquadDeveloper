using SquadDev.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace SquadDev
{
    public class SquadManager : ISquadManager
    {
        //lista com chave e valor -> chave long / valor Squad
        private Dictionary<long, Squad> squad;
        //lista com chave e valor -> chave long / valor Developer
        private Dictionary<long, Developer> devs;

        public SquadManager()
        {
            //ao instanciar a classe squad e dev são instanciados
            squad = new Dictionary<long, Squad>();
            devs = new Dictionary<long, Developer>();
        }

        private Developer GetDev(long devId)
        {
            Developer dev;
            //sintaxe: tenta achar a chave "tif" (Try(entrada)-GetValue(saída-retorno)), 
            //caso não encontre retorna (out) o valor (valor) que pode ser utilizado em seguida dentro do if
            //quando não achar o Id do Developer lançamos uma exceção do Tipo DevNotFoundException
            if (!devs.TryGetValue(devId, out dev))
                throw new DevNotFoundException();
            return dev;
        }

        private Squad GetSquad(long squadId)
        {
            Squad squadRetorno;
            //sintaxe: tenta achar a chave "tif" (Try(entrada)-GetValue(saída-retorno)), 
            //caso não encontre retorna (out) o valor (valor) que pode ser utilizado em seguida dentro do if
            //quando não achar o Id do Squad lançamos uma exceção do Tipo SquadNotFoundException
            if (!squad.TryGetValue(squadId, out squadRetorno))
                throw new SquadNotFoundException();
            return squadRetorno;
        }

        public string GetDevName(long devId)
        {
            Developer dev = GetDev(devId);
            return dev.Name;
        }

        public string GetSquadName(long squadId)
        {
            Squad squad = GetSquad(squadId);
            return squad.Name;
        }

        /// <summary>
        /// Adicionar Novo Squad
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public void AddSquad(long id, string name)
        {
            // ContainsKey pode ser usado para testar(verificar se já existe) chaves antes de inserí-las
            // Caso não encontre queremos lançar uma exceção do tipo UniqueIdentifierException
            if (squad.ContainsKey(id))
                throw new UniqueIdentifierException();

            var Squad = new Squad()
            {
                Id = id,
                Name = name,
            };

            //add elemento na lista
            squad.Add(id, Squad);
        }

        /// <summary>
        /// Adicionar Desenvolvedor no Squad desejado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="squadId"></param>
        /// <param name="name"></param>
        public void AddDev(long id, long squadId, string name)
        {
            // ContainsKey pode ser usado para testar(verificar se já existe) chaves antes de inserí-las
            // Caso não encontre queremos lançar uma exceção do tipo UniqueIdentifierException
            if (devs.ContainsKey(id))
                throw new UniqueIdentifierException();

            Squad squad = GetSquad(squadId);

            var dev = new Developer()
            {
                Id = id,
                SquadId = squad.Id,
                Name = name
            };

            devs.Add(id, dev);

        }
        
        /// <summary>
        /// Setar Tech Leader 
        /// </summary>
        /// <param name="devId"></param>
        public void SetTechLeader(long devId)
        {
            Developer dev = GetDev(devId);

            // O indexador pode ser usado para alterar o valor associado à chave
            squad[dev.SquadId].TechLeaderId = devId;
        }

        public long GetSquadTechLeader(long squadId)
        {
            Squad squad = GetSquad(squadId);

            //Verifica se na lista recuperada contém o Id desejado
            //Caso não tenha, lançamos uma exceção do tipo TechLeadNotFoundException
            if (!squad.TechLeaderId.HasValue)
                throw new TechLeadNotFoundException();

            return squad.TechLeaderId.Value;
        }

        /// <summary>
        /// Retornar lista de valores de devs ids
        /// </summary>
        /// <param name="squadId"></param>
        /// <returns></returns>
        private IEnumerable<Developer> GetDevsOnSquad(long squadId)
        {
            //Para recuperar valores isolados, utiliza-se a propriedade Values
            //a lambda é uma mandeira succinta de declarar uma função, sendo os parámetros da função antes do =>, e o conteúdo da função depois.
            return devs.Values.Where(x => x.SquadId == squadId);
        }

        /// <summary>
        /// Retornar lista de valores de devs ids de um determinado squad
        /// </summary>
        /// <param name="squadId"></param>
        /// <returns></returns>
        public List<long> GetSquadDevs(long squadId)
        {
            Squad squad = GetSquad(squadId);

            //a lambda é uma mandeira succinta de declarar uma função, sendo os parámetros da função antes do =>, e o conteúdo da função depois.
            return GetDevsOnSquad(squadId).
                    Select(x => x.Id).
                    OrderBy(x => x).
                    ToList();
        }
    }
}
