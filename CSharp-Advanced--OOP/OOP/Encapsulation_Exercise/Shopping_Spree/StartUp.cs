using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.ShoppingSpree
{
    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] soroviHora = Console.ReadLine().Split(';');
                string[] soroviProdukti = Console.ReadLine().Split(';');

                List<Person> hora = new List<Person>();
                foreach (var person in soroviHora)
                {
                    string[] info = person.Split('=');
                    decimal pari = decimal.Parse(info[1]);
                    string ime = info[0];

                    Person novChovek = new Person(ime, pari);
                    goto LOOP;
                    
                
                LOOP:

                    hora.Add(novChovek);
                }

                List<Product> produkti = new List<Product>();
                foreach (var product in soroviProdukti)
                {
                    string[] informaciq = product.Split('=');
                    decimal struva = decimal.Parse(informaciq[1]);
                    string ime = informaciq[0];

                    Product newProduct = new Product(ime, struva);
                    produkti.Add(newProduct);
                }

                string prompt;

                while ((prompt = Console.ReadLine()) != "END")
                {
                    string[] info = prompt.Split(' ');
                    string segashnoime = info[0];
                    string segashnoImeProdukt = info[1];

                    foreach (var lichnost in hora)
                    {
                        if (lichnost.Ime.Equals(segashnoime))
                        {
                            foreach (var product in produkti)
                            {
                                if (product.Ime.Equals(segashnoImeProdukt))
                                {
                                    if (lichnost.Kinti >= product.Cena)
                                    {
                                        lichnost.Produkti.Add(product);
                                        lichnost.Kinti -= product.Cena;
                                        Console.WriteLine("{0} bought {1}", lichnost.Ime, product.Ime);
                                    }
                                    else
                                    {
                                        Console.WriteLine("{0} can't afford {1}", lichnost.Ime, product.Ime);
                                    }
                                    goto HERE;
                                }

                            }
                            goto HERE;
                        }

                    }

                HERE:;
                }

                foreach (var person in hora)
                {
                    if (person.Produkti.Count == 0)
                    {
                        Console.WriteLine("{0} - Nothing bought", person.Ime);
                    }
                    else
                    {
                        List<string> imenaNaProdukti = new List<string>();
                        foreach (var product in person.Produkti)
                        {
                            imenaNaProdukti.Add(product.Ime);
                        }

                        string smth = string.Join(", ", imenaNaProdukti);
                        Console.WriteLine("{0} - {1}", person.Ime, smth);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

