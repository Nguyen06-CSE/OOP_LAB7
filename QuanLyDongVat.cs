using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LAB7_TinhThuaKeVaDaHinh
{
    public class QuanLyDongVat
    {
        List<IAnimal> Collection;

        public QuanLyDongVat()
        {
            Collection = new List<IAnimal>();
        }

        public void DocTuFile(string tenFile)
        {
            StreamReader sr = new StreamReader(tenFile);
            string s = "";
            IAnimal animal = null;
            while ((s = sr.ReadLine()) != null)
            {
                var parts = s.Split(',');

                string type = parts[0].Trim();
                string name = parts[1].Trim();
                int age = int.Parse(parts[2].Trim());

                switch (type.ToLower())
                {
                    case "bat":
                        animal = new Bat { Name = name, Age = age };
                        break;
                    case "bird":
                        animal = new Bird { Name = name, Age = age };
                        break;
                    case "lion":
                        animal = new Lion { Name = name, Age = age };
                        break;
                }
                if (animal != null)
                {
                    Collection.Add(animal);
                }
            }
            sr.Close();
        }
    

        // Method to add an animal to the collection
        public void AddAnimal(IAnimal animal)
        {
            Collection.Add(animal);
        }

        // Method to print all animals
        public void PrintAnimals()
        {
            foreach (var animal in Collection)
            {
                Console.WriteLine(animal);
            }
        }

        public int Count (string name)
        {
            int count = 0;
            foreach(var animal in Collection)
            {
                if(animal.Name == name)
                {
                    ++count; 
                }
            }
            return count;
        }

        public int CountBat()
        {
            return Count("bat");
        }
        public int CountLiom()
        {
            return Count("lion");
        }
        public int CountBird()
        {
            return Count("bird");
        }
                                                            //do not use LINQ 
        //public int CountFly()
        //{
        //    int flyingCount = 0;

        //    foreach (var animal in Collection)
        //    {
        //        if (animal is IFlyable)
        //        {
        //            flyingCount++;
        //        }
        //    }
        //    return flyingCount;
        //}
        //public int CountNonFly()
        //{
        //    int nonFlyingCount = 0;

        //    foreach (var animal in Collection)
        //    {
        //        if (!(animal is IFlyable))
        //        {
        //            nonFlyingCount++;
        //        }
        //    }
        //    return nonFlyingCount;
        //}
        //public int CountFlyWithAgeAndName(string name, int age)
        //{
        //    int count = 0;
        //    foreach( var animal in Collection)
        //    {
        //        if (animal is IFlyable && animal.Name == name && animal.Age == age)
        //        {
        //            ++count ;
        //        } 
        //    }
        //    return count;
        //}
        //public int CountNonFlyWithAgeAndName(string name, int age)
        //{
        //    int count = 0;
        //    foreach (var animal in Collection)
        //    {
        //        if (!(animal is IFlyable) && animal.Name == name && animal.Age == age)
        //        {
        //            ++count;
        //        }
        //    }
        //    return count;
        //}

                                                                //used LINQ
        //ưu điểm code ngắn và tính tái sử dụng cao 
        //Func<IAnimal, bool> predicate đưa vào đối tượng IAnimal và đưa đầu ra kiểu bool 
        public int CountAnimals(Func<IAnimal, bool> predicate)
        {
            //nếu điều kiện đúng thì đếm và trả về 
            return Collection.Count(predicate);
        }

        public int CountFly()
        {
            return CountAnimals(animal => animal is IFlyable);
        }

        public int CountNonFly()
        {
            return CountAnimals(animal => !(animal is IFlyable));
        }

        public int CountFlyWithAgeAndName(string name, int age)
        {
            return CountAnimals(animal => animal is IFlyable && animal.Name == name && animal.Age == age);
        }

        public int CountNonFlyWithAgeAndName(string name, int age)
        {
            return CountAnimals(animal => !(animal is IFlyable) && animal.Name == name && animal.Age == age);
        }

        public List<string> RemoveDuplicate()
        {
            List<string> result = new List<string>();
            foreach (var item in Collection)
            {
                if (!result.Contains(item.Name))
                {
                    result.Add(item.Name);
                }
            }
            return result;
        }


        public string FindAnimalsByNum(bool findHighest)
        {
            List<string> uniqueAnimals = RemoveDuplicate();
            if (uniqueAnimals.Count == 0)
                return string.Empty;  // Handle empty case

            string result = uniqueAnimals[0];
            int condition = Count(result);

            foreach (var item in uniqueAnimals)
            {
                int itemCount = Count(item);
                if ((findHighest && itemCount > condition) ||
                    (!findHighest && itemCount < condition))
                {
                    condition = itemCount;
                    result = item;
                }
            }

            return result;
        }

        public string FindHighestAnimal()
        {
            return FindAnimalsByNum(true);
        }

        public string FindLeastAnimal()
        {
            return FindAnimalsByNum(false);
        }

        //public string FindHighestAnimal()
        //{
        //    List<string> uniqueAnimals = RemoveDuplicate();
        //    string mostCommonAnimal = "";
        //    int maxCount = 0;

        //    foreach (var animalName in uniqueAnimals)
        //    {
        //        int count = Count(animalName);
        //        if (count > maxCount)
        //        {
        //            maxCount = count;
        //            mostCommonAnimal = animalName;
        //        }
        //    }

        //    return mostCommonAnimal;
        //}

        //public string FindLeastAnimal()
        //{
        //    List<string> uniqueAnimals = RemoveDuplicate();
        //    string mostCommonAnimal = "";
        //    int minCount = int.MaxValue;

        //    foreach (var animalName in uniqueAnimals)
        //    {
        //        int count = Count(animalName);
        //        if (count < minCount)
        //        {
        //            minCount = count;
        //            mostCommonAnimal = animalName;
        //        }
        //    }
        //    return mostCommonAnimal;
        //}

        public List<string> FindAnimalsByType(string type)
        {
            List<string> result = new List<string>();
            foreach (var animal in Collection)
            {
                if (animal.GetType().Name == type)
                {
                    result.Add(animal.Name);
                }
            }
            return result;
        }

        public List<string> FindBreedOfBat()
        {
            return FindAnimalsByType("bat");
        }
        public List<string> FindBreedOfLion()
        {
            return FindAnimalsByType("lion");
        }
        public List<string> FindBreedOfBird()
        {
            return FindAnimalsByType("bird");
        }
        //this function canbe replace name.Length (i think that :)) )
        //public int CountLengthOfName(string name)
        //{
        //    int count = 0;
        //    while (name[count] != null) // This will throw an error
        //    {
        //        count++;
        //    }
        //    return count;
        //}
        public List<string> FindNameByLength(bool findLongest)
        {
            List<string> result = new List<string>();
            int length = findLongest ? 0 : int.MaxValue;

            foreach (var animal in Collection)
            {
                if ((findLongest && animal.Name.Length > length) ||
                    (!findLongest && animal.Name.Length < length))
                {
                    length = animal.Name.Length;
                    result.Clear();
                    result.Add(animal.Name);
                }
                else if (animal.Name.Length == length)
                {
                    result.Add(animal.Name);
                }
            }
            return result;
        }

        // Method to find the longest name
        public List<string> FindTheLongestName()
        {
            return FindNameByLength(true);
        }

        // Method to find the shortest name
        public List<string> FindTheLeastName()
        {
            return FindNameByLength(false);
        }

        public List<string> FindAge(bool findOldest)
        {
            List<string> result = new List<string>();
            int condition = findOldest ? 0 : int.MaxValue;

            foreach (var animal in Collection)
            {
                if ((findOldest && animal.Age > condition) ||
                    (!findOldest && animal.Age < condition))
                {
                    condition = animal.Age;
                    result.Clear(); // Reset the list as a new extreme value is found
                    result.Add(animal.Name);
                }
                else if (animal.Age == condition)
                {
                    result.Add(animal.Name);
                }
            }

            return result;
        }


        public List<string> FindTheOldest()
        {
            return FindAge(true);
        }

        public List<string> FindTheYoungestName()
        {
            return FindAge(false);
        }

        public List<string> FindTheLengestOfNameByBreed()
        {
            List<string> result = new List<string>();
            int maxVal = 0;
            foreach (var animal in Collection)
            {

            }

            return result;
        }

        public List<IAnimal> SameSpecies(string type)
        {
            List<IAnimal> result = new List<IAnimal>();
            foreach (var animal in Collection)
            {
                if (animal.GetType().Name == type)
                {
                    result.Add(animal);
                }
            }
            return result;
        }

        public List<string> FindLongestNameBySpecies(string type)
        {
            List<IAnimal> filteredAnimals = new List<IAnimal>();
            filteredAnimals = SameSpecies(type);

            // Tìm độ dài tên nhỏ nhất hoặc lớn nhất
            int max = 0;

            foreach(var animal in filteredAnimals)
            {
                if(animal.Name.Length > max)
                {
                    max = animal.Name.Length;
                }
            }

            // Lọc ra những con có độ dài tên phù hợp
            List<string> result = new List<string>();
            foreach (var animal in filteredAnimals)
            {
                if (animal.Name.Length == max)
                {
                    result.Add(animal.Name);
                }
            }

            return result;
        }

        public List<string> FindShortestNameBySpecies(string type)
        {
            List<IAnimal> filteredAnimals = new List<IAnimal>();
            filteredAnimals = SameSpecies(type);

            // Tìm độ dài tên nhỏ nhất hoặc lớn nhất
            int min = int.MaxValue;

            foreach (var animal in filteredAnimals)
            {
                if (animal.Name.Length < min)
                {
                    min = animal.Name.Length;
                }
            }

            // Lọc ra những con có độ dài tên phù hợp
            List<string> result = new List<string>();
            foreach (var animal in filteredAnimals)
            {
                if (animal.Name.Length == min)
                {
                    result.Add(animal.Name);
                }
            }

            return result;
        }

        public List<string> FindOldestAgeBySpecies(string type)
        {
            List<IAnimal> filteredAnimals = new List<IAnimal>();
            filteredAnimals = SameSpecies(type);

            // Tìm độ dài tên nhỏ nhất hoặc lớn nhất
            int max = 0;

            foreach (var animal in filteredAnimals)
            {
                if (animal.Age > max)
                {
                    max = animal.Age;
                }
            }

            // Lọc ra những con có độ dài tên phù hợp
            List<string> result = new List<string>();
            foreach (var animal in filteredAnimals)
            {
                if (animal.Age == max)
                {
                    result.Add(animal.Name);
                }
            }

            return result;
        }
        public List<string> FindYoungestAgeBySpecies(string type)
        {
            List<IAnimal> filteredAnimals = new List<IAnimal>();
            filteredAnimals = SameSpecies(type);

            // Tìm độ dài tên nhỏ nhất hoặc lớn nhất
            int min = int.MaxValue;

            foreach (var animal in filteredAnimals)
            {
                if (animal.Age < min)
                {
                    min = animal.Age;
                }
            }

            // Lọc ra những con có độ dài tên phù hợp
            List<string> result = new List<string>();
            foreach (var animal in filteredAnimals)
            {
                if (animal.Age == min)
                {
                    result.Add(animal.Name);
                }
            }

            return result;
        }

        public List<IAnimal> FindFlyingAnimals()
        {
            List<IAnimal> result = new List<IAnimal>();

            foreach (var animal in Collection)
            {
                if (animal is IFlyable)
                {
                    result.Add(animal);
                }
            }

            return result;
        }

        public List<IAnimal> FindCanNotFlyingAnimals()
        {
            List<IAnimal> result = new List<IAnimal>();

            foreach (var animal in Collection)
            {
                if (!(animal is IFlyable))
                {
                    result.Add(animal);
                }
            }

            return result;
        }


        public void Swap (List<IAnimal> list, int index1, int index2)
        {
            var temp = list[index1]; 
            list[index1] = list[index2];
            list[index2] = temp;
        }

        public List<IAnimal> SortAnimalsByAge(bool ascending)
        {
            List<IAnimal> res = new List<IAnimal>(Collection);
            for(int i = 0; i < Collection.Count() - 1; i++)
            {
                for(int j = i + 1; j < res.Count(); j++)
                {
                    bool swapConditon = ascending ? res[i].Age > res[j].Age : res[i].Age < res[j].Age;

                    if (swapConditon)    Swap(res, i, j);
                }
            }
            return res;
        }

        public List<IAnimal> SortByAgeAscending()
        {
            return SortAnimalsByAge(true);
        }

        public List<IAnimal> SortByAgeDescending()
        {
            return SortAnimalsByAge(false);
        }

        public List<IAnimal> SortAnimalsByName(bool ascending)
        {
            List<IAnimal> res = new List<IAnimal>(Collection);
            for (int i = 0; i < Collection.Count() - 1; i++)
            {
                for (int j = i + 1; j < res.Count(); j++)
                {
                     var swapCondition = ascending
                     ? string.Compare(res[i].Name, res[j].Name) > 0
                     : string.Compare(res[i].Name, res[j].Name) < 0;
                    if (swapCondition) Swap(res, i, j);
                }
            }
            return res;
        }

        public List<IAnimal> SortByNameAscending()
        {
            return SortAnimalsByName(true);
        }

        public List<IAnimal> SortByNameDescending()
        {
            return SortAnimalsByName(false);
        }


        //this function use GetType()
        public void RemoveAnimalsByType(string typeName)
        {
            for (int i = Collection.Count - 1; i >= 0; i--)
            {
                if (Collection[i].GetType().Name == typeName)
                {
                    Collection.RemoveAt(i);
                }
            }
        }
        ////this function do not use GetType()
        //public void RemoveAllLions()
        //{
        //    for (int i = Collection.Count - 1; i >= 0; i--)
        //    {
        //        if (Collection[i] is Lion)
        //        {
        //            Collection.RemoveAt(i);
        //        }
        //    }
        //}

        //public void RemoveAllBirds()
        //{
        //    for (int i = Collection.Count - 1; i >= 0; i--)
        //    {
        //        if (Collection[i] is Bird)
        //        {
        //            Collection.RemoveAt(i);
        //        }
        //    }
        //}

        //public void RemoveAllBats()
        //{
        //    for (int i = Collection.Count - 1; i >= 0; i--)
        //    {
        //        if (Collection[i] is Bat)
        //        {
        //            Collection.RemoveAt(i);
        //        }
        //    }
        //}

        public void RemoveAnimalsCanFly()
        {
            for (int i = Collection.Count - 1; i >= 0; i--)
            {
                if (Collection[i] is IFlyable)
                {
                    Collection.RemoveAt(i);
                }
            }
        }
        public void RemoveAnimalsCanNotFly()
        {
            for (int i = Collection.Count - 1; i >= 0; i--)
            {
                if (!(Collection[i] is IFlyable))
                {
                    Collection.RemoveAt(i);
                }
            }
        }
        public void RemoveAnimalsCanFlyByNameAndAge(int age, string name)
        {
            for (int i = Collection.Count - 1; i >= 0; i--)
            {
                if (Collection[i] is IFlyable && Collection[i].Age == age && string.Compare(Collection[i].Name,name)==0)
                {
                    Collection.RemoveAt(i);
                }
            }
        }
        public void RemoveAnimalsCanNotFlyByNameAndAge(int age, string name)
        {
            for (int i = Collection.Count - 1; i >= 0; i--)
            {
                if (!(Collection[i] is IFlyable) && Collection[i].Age == age && string.Compare(Collection[i].Name, name) == 0)
                {
                    Collection.RemoveAt(i);
                }
            }
        }


        //use LINQ and reuse function FindTheYoungestName() and FindTheOldest()
        public void EraseAllAnimalsYoungest()
        {
            List<string> youngestNames = FindTheYoungestName();
            Collection.RemoveAll(animal => youngestNames.Contains(animal.Name));
        }

        public void EraseAllAnimalsOldest()
        {
            List<string> oldestNames = FindTheOldest();
            Collection.RemoveAll(animal => oldestNames.Contains(animal.Name));
        }

        public List<string> GetType(List<IAnimal> tmp)
        {
            List<string> types = new List<string>();
            for (int i = 0; i < tmp.Count; i++)
            {
                types.Add(tmp[i].GetType().Name);
            }

            return types;
        }

        public List<IAnimal> GetAnimalByName(List<string> names)
        {
            List<IAnimal> ds = new List<IAnimal>();

            foreach (var animal in Collection)
            {
                foreach (var item in names)
                {
                    if (string.Compare(animal.Name, item) == 0)
                    {
                        ds.Add(animal);
                    }
                }
            }
            return ds;
        }

        //public void EraseAllAnimalsBySpeciesOldest()
        //{
        //    List<IAnimal> ds = GetAnimalByName(FindTheOldest());
        //    List<string> types = GetType(ds);
        //    foreach (string typeName in types)
        //    {
        //        for (int i = Collection.Count - 1; i >= 0; i--)
        //        {
        //            if (Collection[i].GetType().Name == typeName)
        //            {
        //                Collection.RemoveAt(i);
        //                break;
        //            }
        //        }
        //    }
        //}

        //use linq
        public void EraseAllAnimalsBySpeciesOldest()
        {
            var oldestAnimalNames = FindTheOldest();
            var speciesToRemove = new HashSet<string>(
                Collection
                    .Where(animal => oldestAnimalNames.Contains(animal.Name))
                    .Select(animal => animal.GetType().Name)
            );

            Collection.RemoveAll(animal => speciesToRemove.Contains(animal.GetType().Name));
        }

        public void EreaseAnimals()
        {
            Collection.Clear();
        }

        public void EreaseAtPositionX(int position)
        {
            Collection.RemoveAt(position);
        }


        //public List<(int, string)> CaculateTheTotalAgeBySpecie()
        //{
        //    List<(int, string)> result = new List<(int, string)>();
        //    List<string> species = GetType(Collection);
        //    HashSet<string> uniqueSpecies = new HashSet<string>(species); 

        //    foreach (string type in uniqueSpecies)
        //    {
        //        int totalAge = 0;
        //        foreach (var animal in Collection)
        //        {
        //            if (animal.GetType().Name == type)
        //            {
        //                totalAge += animal.Age;
        //            }
        //        }
        //        result.Add((totalAge, type));
        //    }

        //    return result;
        //}

        public List<(int, string)> CaculateTheTotalAgeBySpecie()
        {
            Dictionary<string, int> totalAgeByType = new Dictionary<string, int>();

            foreach (var animal in Collection)
            {
                string type = animal.GetType().Name;

                if (!totalAgeByType.ContainsKey(type))
                {
                    totalAgeByType[type] = 0;
                }

                totalAgeByType[type] += animal.Age;
            }

            List<(int, string)> result = new List<(int, string)>();
            foreach (var pair in totalAgeByType)
            {
                result.Add((pair.Value, pair.Key));
            }

            return result;
        }

        public int CaculateTheTotalAgeCanFly()
        {
            int totalAge = 0;
            foreach (var animal in Collection)
            {
                if(animal is IFlyable)
                {
                    totalAge += animal.Age;
                }
            }
            return totalAge;
        }

        public int CaculateTheTotalAgeCanNotFly()
        {
            int totalAge = 0;
            foreach (var animal in Collection)
            {
                if (!(animal is IFlyable))
                {
                    totalAge += animal.Age;
                }
            }
            return totalAge;
        }

        public void AddAnimalAtPosition(IAnimal animal, int position)
        {
            if (position < 0 || position > Collection.Count)
            {
                Console.WriteLine("vi tri ko hop le");
            }

            Collection.Insert(position, animal);
        }

        public void DisplayAscendingByName()
        {
            for(int i = 0; i < Collection.Count-1; i++)
            {
                for (int j = i+1; j < Collection.Count; j++)
                {
                    if (string.Compare(Collection[i].Name, Collection[j].Name) < 0)
                    {
                        Swap(Collection, i, j);
                    }
                }
            }
            PrintAnimals();
        }

        public void DisplayDecendingByName()
        {
            for (int i = 0; i < Collection.Count - 1; i++)
            {
                for (int j = i + 1; j < Collection.Count; j++)
                {
                    if (string.Compare(Collection[i].Name, Collection[j].Name) > 0)
                    {
                        Swap(Collection, i, j);
                    }
                }
            }
            PrintAnimals();
        }

        public void DisplayAscendingByAge()
        {
            for (int i = 0; i < Collection.Count - 1; i++)
            {
                for (int j = i + 1; j < Collection.Count; j++)
                {
                    if (Collection[i].Age > Collection[j].Age)
                    {
                        Swap(Collection, i, j);
                    }
                }
            }
            PrintAnimals();
        }

        public void DisplayDecendingByAge()
        {
            for (int i = 0; i < Collection.Count - 1; i++)
            {
                for (int j = i + 1; j < Collection.Count; j++)
                {
                    if (Collection[i].Age < Collection[j].Age)
                    {
                        Swap(Collection, i, j);
                    }
                }
            }
            PrintAnimals();
        }

        public void DisplayAnimalsGrouped()
        {
            List<IAnimal> bats = new List<IAnimal>();
            List<IAnimal> lions = new List<IAnimal>();
            List<IAnimal> birds = new List<IAnimal>();

            foreach (var animal in Collection)
            {
                string type = animal.GetType().Name;

                if (type == "Bat") bats.Add(animal);
                else if (type == "Lion") lions.Add(animal);
                else if (type == "Bird") birds.Add(animal);
            }

            Console.WriteLine("--- Bat ---");
            foreach (var a in bats)
                Console.WriteLine($"{a.Name} - {a.Age}");

            Console.WriteLine("--- Lion ---");
            foreach (var a in lions)
                Console.WriteLine($"{a.Name} - {a.Age}");

            Console.WriteLine("--- Bird ---");
            foreach (var a in birds)
                Console.WriteLine($"{a.Name} - {a.Age}");
        }

        public List<IAnimal> GetSortedByGroup()
        {
            string[] groupOrder = { "Bat", "Lion", "Bird" };
            List<IAnimal> sorted = new List<IAnimal>();

            // Go through each group in order
            foreach (var group in groupOrder)
            {
                foreach (var animal in Collection)
                {
                    if (animal.GetType().Name == group)
                    {
                        sorted.Add(animal);
                    }
                }
            }
            return sorted;
        }


    }
}
