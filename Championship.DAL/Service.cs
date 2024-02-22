using Championship.DAL.Models;
using Championship.DAL.Repositories;
using System.Linq;

namespace Championship.DAL
{
    public class Service
    {
        private readonly TeamRepository _repository;

        public Service()
        {
            _repository = new TeamRepository(new Context());
        }

        public List<Team> GetTeams()
        {
            return _repository.GetTeams();
        }

        public Team? TeamWithTheMostWins
            => (from team in _repository.GetTeams()
                orderby team.Wins descending
                select team).FirstOrDefault();
        public Team? TeamWithTheMostLoses
            => (from team in _repository.GetTeams()
                orderby team.Loses descending
                select team).FirstOrDefault();
        public Team? TeamWithTheMostDraws
            => (from team in _repository.GetTeams()
                orderby team.Draws descending
                select team).FirstOrDefault();
        public Team? TeamWithTheMostGoalsConceded
            => (from team in _repository.GetTeams()
                orderby team.GoalsConceded descending
                select team).FirstOrDefault();
        public Team? TeamWithTheMostGoalsScored
            => (from team in _repository.GetTeams()
                orderby team.GoalsScored descending
                select team).FirstOrDefault();

        public bool AddTeam(Team? team) 
        {
            if (team == null)
                return false;

            if (!IsUnique(team)) 
                return false;
            
            _repository.Add(team);
            return true;
        }
        public bool EditTeam(string? name, string? town, Team? newTeam) 
        {
            if (name == null || town == null || newTeam == null)
                return false;

            var team = FindTeamByNameAndTown(name, town);

            if (team == null)
                return false;

            _repository.Remove(team);
            _repository.Add(team);

            return true;
        }
        public bool RemoveTeam(string? name, string? town) 
        {
            if (name == null || town == null)
                return false;

            var team = FindTeamByNameAndTown(name, town);

            if (team == null)
                return false;

            _repository.Remove(team);
            return true;
        }

        private bool IsUnique(Team team) 
        {
            if (_repository.GetTeams()
                .Where(t => t.Id == team.Id || t.Name == team.Name)
                .Count() != 0)
                return false;
            return true;
        }

        public List<Team> FindTeamsByTown(string? town)
            => (from team in _repository.GetTeams()
                where team.Town == town
                select team).ToList();
        public Team? FindTeamByName(string? name)
            => (from team in _repository.GetTeams()
                where team.Name == name
                select team).FirstOrDefault();
        public Team? FindTeamByNameAndTown(string? name, string? town)
            => (from team in _repository.GetTeams()
                where team.Name == name && team.Town == town
                select team).FirstOrDefault();

        public Dictionary<Team, int> GetGoalDifferenceByTeam()
        {
            var goalDifferenceMap = new Dictionary<Team, int>();

            foreach (var team in _repository.GetTeams())
                goalDifferenceMap.Add(team, team.GoalsScored - team.GoalsConceded);

            return goalDifferenceMap;
        }


    }
}
