﻿using _1er_ParcialAplicada2.Data;
using _1er_ParcialAplicada2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace _1er_ParcialAplicada2.Controllers
{
    public class ArticulosController
    {
        public static bool Guardar(Articulos Articulo)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                if (Articulo.ArticuloId == 0)
                    paso = Insertar(Articulo);
                else
                    paso = Modificar(Articulo);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static bool Insertar(Articulos Articulo)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Articulos.Add(Articulo);
                paso = contexto.SaveChanges()>0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static bool Modificar(Articulos Articulo)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Entry(Articulo).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Articulos Buscar(int Id)
        {
            Contexto contexto = new Contexto();
            Articulos Articulo;


            try
            {
                Articulo = contexto.Articulos.Find(Id);
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Articulo;
        }

        public static bool Eliminar(int Id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            


            try
            {
                Articulos Articulo = contexto.Articulos.Find(Id);
                contexto.Articulos.Remove(Articulo);
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static List<Articulos> GetList(Expression<Func<Articulos, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Articulos> lista = new List<Articulos>();
            try
            {
                lista = contexto.Articulos.Where( expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
