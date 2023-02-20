# Ef7 Bulk Operations

The bulk operation is one of the major features of EF introduced by Entity Framework 7. The main attention of EF7 is dragged by its introducing features “ExecuteUpdate” and “ExecuteDelete” as well as async versions of them.

This new ExcuteUpdate allows us to write a LINQ query and run bulk updates with the matching query. Similarly, ExcuteDelete allows bulk deletes. This brings us significant performance improvements on bulk updates and deletes.

I only focus on ExecuteUpdate here. But it is similar in ExecuteDelete as well. Before the release of EF7, bulk updates were done by loading all the entities matched by the given query into memory and changing the required properties.

Sometimes our requirement is only to change only one or a couple of properties, but the entire row is loaded by EF to work on the change tracker regardless of how many properties are required to change.

During the execution of the saveChanges method, in-memory entities are compared with the snapshot by EF to figure out the changed properties and the properties that need to persist in the database. So you can see that this traditional way of bulk updating is a bit inefficient considering the in-memory data loading and multiple database round trips.

The larger the collection, efficiency gets far worse. If you have a look at the translated query which is issued to the database in this scenario you might get why this is an inefficient way. because there are multiple update statements within one command to update every single row. But in the practical usage of SQL kind of scenarios are handled by adding filters to the Where clause instead of a single updating of each row.

Let’s see how the newly introduced way of ExecuteUpdate in EF7 is far better than the traditional way. New ExecuteUpdate directly translates the LINQ query into the matching query and sends it to the database. It is just as simple as mentioning the property to be changed with its new value using the SetProperty method. Here you can have the advantage of lambda expressions too.

So, the EF takes care of direct translation by setting the property to be changed to SQL set and the WHERE condition of the LINQ to the WHERE clause of SQL.
