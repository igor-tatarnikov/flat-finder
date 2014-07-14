using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Design;
using System.Linq;
using System.Reflection;
using FlatFinder.Core.Configuration;
using FlatFinder.Data;
using FlatFinder.Data.Infrastructure;
using FlatFinder.Init.Creators;

namespace FlatFinder.Init
{
    class Program
    {
        #region Fields

        private const int ExitActionId = 0;
        private const string DataAssemblyName = "FlatFinder.Data.dll";

        #endregion

        private static IEnumerable<DatabaseAction> AvailableActions
        {
            get
            {
                return new List<DatabaseAction>
                                {
                                    new DatabaseAction {Id = ExitActionId, Name = "Exit"},
                                    new DatabaseAction {Id = 1, Action = CreateAndFill, Name = "Database schema creation and base data filling"}
                                };
            }
        }

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                PrintAvailableActions();

                var action = ReadAction();

                if (action.Id == ExitActionId)
                {
                    exit = true;
                }
                else
                {
                    PerformAction(action);
                }
            }
        }

        #region Actions

        private static void CreateAndFill()
        {
            Create();
            FillBaseData();
            FillTestData();
        }

        private static void Create()
        {
            var migrator = GetDbMigrator();
            migrator.Update();
        }

        private static DbMigrator GetDbMigrator()
        {
            return new DbMigrator(new DbMigrationsConfiguration()
            {
                AutomaticMigrationDataLossAllowed = true,
                AutomaticMigrationsEnabled = true,
                MigrationsAssembly = Assembly.LoadFrom(DataAssemblyName),
                TargetDatabase = new DbConnectionInfo(Config.DatabaseConnectionString, "System.Data.SqlClient"),
                MigrationsDirectory = "DatabaseMigrations",
                ContextType = typeof(FlatFinderDbContext),
                CodeGenerator = new CSharpMigrationCodeGenerator(),
                MigrationsNamespace = "FlatFinder.Data"
            });
        }


        private static void FillBaseData()
        {
            var context = new FlatFinderDbContext(Config.DatabaseConnectionString);
        }

        private static void FillTestData()
        {
            var repoFactory = new RepositoryFactories();
            var repositoryProvider = new RepositoryProvider(repoFactory);
            var uow = new FlatFinderUow(repositoryProvider);

            new ContactInfoCreator().Initialize(uow);
            new DistrictCreator().Initialize(uow);
            new AddressCreator().Initialize(uow);
            new FlatInfoCreator().Initialize(uow);
            new DetailedFlatAdCreator().Initialize(uow);
        }

        #endregion

        #region Helper methods

        private static void PrintAvailableActions()
        {
            Console.WriteLine("Choose action:");

            foreach (var action in AvailableActions)
            {
                Console.WriteLine("{0}. {1}", action.Id, action.Name);
            }
        }

        private static DatabaseAction ReadAction()
        {
            while (true)
            {
                var line = Console.ReadLine();

                int actionId;
                if (int.TryParse(line, out actionId))
                {
                    var action = GetAction(actionId);
                    if (action != null)
                    {
                        return action;
                    }
                }
                Console.WriteLine("Invalid action chosen! Please repeat again.");
            }
        }

        private static DatabaseAction GetAction(int actionId)
        {
            return AvailableActions.FirstOrDefault(x => x.Id == actionId);
        }

        private static void PerformAction(DatabaseAction action)
        {
            Console.WriteLine("{0}: {1} started...", DateTime.Now, action.Name);

            action.Action();

            Console.WriteLine("{0}: {1} ended.", DateTime.Now, action.Name);
            Console.WriteLine();
        }

        #endregion
    }
}
