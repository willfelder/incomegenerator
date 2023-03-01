using Course.Entities.Enums;

namespace Course.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public List<HourContract> Contracts { get; private set; } = new List<HourContract>();

        public Worker(string name, WorkerLevel level, double baseSalary, Department departament)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = departament;
        }

        public void AddContract(HourContract hourContract)
        {
            Contracts.Add(hourContract);
        }

        public void RemoveContract(HourContract hourContract)
        {
            Contracts.Remove(hourContract);
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary;
            
            foreach (HourContract contract in Contracts)
            {
                if (contract.Date.Year == year && contract.Date.Month == month)
                {
                    sum += contract.TotalValue();
                }
            }
            return sum;
        }
    }
}
