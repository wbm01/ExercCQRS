﻿namespace Cqrs.Repository;

public class MongoRepositorySettings
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}