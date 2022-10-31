using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using Ejercicio1.Models;

namespace Ejercicio1.Models
{
    public class sqlconex
    {
        private readonly SQLiteAsyncConnection db;

        public sqlconex(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Contactos>();
        }

        public Task<int> Crearcontacto (Contactos contacto)
        {
            return db.InsertAsync(contacto);
        }

        public Task<List<Contactos>>Leercontacto()
        {
            return db.Table<Contactos>().ToListAsync();
        }
         
        public Task<int>Updatecontacto(Contactos contacto)
        {
            return db.UpdateAsync(contacto);
        }

        public Task<int> Borrarcontacto(Contactos contacto)
        {
            return db.DeleteAsync(contacto);
        }

        public Task<List<Contactos>> Buscar(string buscar)
        {
            return db.Table<Contactos>().Where(p=> p.Nombre.StartsWith(buscar)).ToListAsync();
        }


    }
}
