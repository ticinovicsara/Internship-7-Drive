﻿using DumpDrive.Domain.Repositories;

namespace DumpDrive.Domain.Factories
{
    public class RepositoryFactory
    {
        public static TRepository Create<TRepository>()
            where TRepository : BaseRepository
        {
            var dbContext = DbContextFactory.GetDumpDriveDbContext();
            var repositoryInstance = Activator.CreateInstance(typeof(TRepository), dbContext) as TRepository;

            return repositoryInstance!;
        }
    }
}
