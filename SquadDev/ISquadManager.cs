using System.Collections.Generic;

namespace SquadDev
{
    public interface ISquadManager
    {
        void AddDev(long id, long squadId, string name);
        void AddSquad(long id, string name);
        string GetDevName(long devId);
        long GetSquadTechLeader(long SquadId);
        List<long> GetSquadDevs(long squadId);
        string GetSquadName(long squadId);
        void SetTechLeader(long DevId);
    }
}