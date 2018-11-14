
using MyCouch;

namespace CouchDb
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var client = new MyCouchClient("http://localhost:5984/", "test"))
            {

                //POST with server generated id
                client.Documents.PostAsync("{\"name\":\"Daniel\"}");

                //PUT for client generated id
                 client.Documents.PutAsync("1", "{\"name\":\"Daniel\"}");

                //PUT for updates
                 client.Documents.PutAsync("1", "Prathesh", "{\"name\":\"Daniel Wertheim\"}");

                //PUT for updates with _rev in JSON
                 client.Documents.PutAsync("1", "{\"_rev\": \"docRevision\", \"name\":\"Daniel Wertheim\"}");

                //Using entities
                var me = new Person { Id = "2", Name = "Prathesh" };
                client.Entities.PutAsync(me);

                //Using anonymous entities
                client.Entities.PostAsync(new { Name = "George" });


                var n = client.Documents.GetAsync("2");
            }
        }
    }
}
