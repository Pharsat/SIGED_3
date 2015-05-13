using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIGED_3.CRM.Model.Negocio.Entidades;
using System.Security.Cryptography;
namespace SIGED_3.CRM.Model.AccesoDeRecursos.OAD
{
    internal class CuentasOAD
    {
        /// <summary>
        /// Selecciona todos los registros de la tabla Cuentas
        /// </summary>
        /// <returns>Lista de registros tipo Cuentas</returns>
        public List<Cuentas> Seleccionar_All()
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Cuentas.ToList();
            }
        }
        /// <summary>
        /// Selecciona todos los registros de la tabla Cuentas
        /// </summary>
        /// <param name=Id>Identificador de la Cuentas</param>
        /// <returns>Objeto singular del tipo Cuentas</returns>
        public List<Cuentas> Seleccionar_Id(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                var query = from p in dc.Cuentas
                            where p.Id == Id
                            select p;
                return query.ToList();
            }
        }

        public Cuentas Seleccionar_Id_Unico(long Id)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.Cuentas.Single(p => p.Id == Id);
            }
        }

        /// <summary>
        /// Guarda un objeto de tipo Cuentas en la base de datos.
        /// </summary>
        /// <param name=objCuentas>Objeto Cuentas a guardar</param>
        public void Guardar(Cuentas objCuentas)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                objCuentas.Contrasena = EncriptarContrasena(objCuentas.Contrasena);
                dc.Cuentas.InsertOnSubmit(objCuentas);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Guarda el objeto cuenta y obtiene su Id
        /// </summary>
        /// <param name="objCuentas">cuenta a guardar</param>
        public long Guardar_2(Cuentas objCuentas)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                objCuentas.Contrasena = EncriptarContrasena(objCuentas.Contrasena);
                dc.Cuentas.InsertOnSubmit(objCuentas);
                dc.SubmitChanges();
                return dc.Cuentas.Max(p => p.Id);
            }
        }
        /// <summary>
        /// Elimina un objeto del tipo Cuentas, se recibe su Id unicamente
        /// </summary>
        /// <param name=Id>Identificativo del(a) Cuentas</param>
        public void Eliminar(Cuentas objCuentas)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Cuentas _objCuentas = dc.Cuentas.Single(p => p.Id == objCuentas.Id);
                dc.Cuentas.DeleteOnSubmit(_objCuentas);
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Actualiza una Cuentas, se basa en el identificador para actualizar el objeto.
        /// </summary>
        /// <param name=objCuentas>Objeto del tipo Cuentas</param>
        public void Actualizar(Cuentas objCuentas)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                Cuentas _objCuentas = dc.Cuentas.Single(p => p.Id == objCuentas.Id);
                _objCuentas.Id = objCuentas.Id;
                _objCuentas.Id_GrupoDeMiembros = objCuentas.Id_GrupoDeMiembros;
                _objCuentas.Id_Miembro = objCuentas.Id_Miembro;
                _objCuentas.Id_Rol = objCuentas.Id_Rol;
                _objCuentas.Usuario = objCuentas.Usuario;
                _objCuentas.Contrasena = objCuentas.Contrasena;
                _objCuentas.ContrasenaProvisional = objCuentas.ContrasenaProvisional;
                _objCuentas.dtFechaApertura = objCuentas.dtFechaApertura;
                _objCuentas.dtFechaCierre = objCuentas.dtFechaCierre;
                _objCuentas.EstadoDeActivacion = objCuentas.EstadoDeActivacion;
                _objCuentas.CodigoDeActivacion = objCuentas.CodigoDeActivacion;
                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Loguea el usuario ante el sistema
        /// </summary>
        /// <param name="Usuario">Usuario del miembro</param>
        /// <param name="Contrasena">Constraseña del miembro</param>
        /// <returns>Retorna el miembro si lo hay si no retorna nulo y el logueo es invalido</returns>
        public Cuentas Validar_Usuario(string Usuario, string Contrasena)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (dc.Cuentas.Any(p => p.Usuario == Usuario && p.Contrasena == EncriptarContrasena(Contrasena) && p.EstadoDeActivacion == true))
                {
                    Cuentas objCuenta = dc.Cuentas.Single(p => p.Usuario == Usuario && p.Contrasena == EncriptarContrasena(Contrasena) && p.EstadoDeActivacion == true);
                    if (objCuenta.dtFechaApertura <= DateTime.Now.ToUniversalTime() && DateTime.Now.ToUniversalTime() <= objCuenta.dtFechaCierre)
                    {
                        return objCuenta;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    if (dc.Cuentas.Any(p => p.Usuario == Usuario && p.ContrasenaProvisional == EncriptarContrasena(Contrasena) && p.EstadoDeActivacion == true))
                    {
                        Cuentas objCuenta = dc.Cuentas.Single(p => p.Usuario == Usuario && p.ContrasenaProvisional == EncriptarContrasena(Contrasena) && p.EstadoDeActivacion == true);
                        objCuenta.Contrasena = objCuenta.ContrasenaProvisional;
                        objCuenta.ContrasenaProvisional = null;
                        dc.SubmitChanges();
                        if (objCuenta.dtFechaApertura <= DateTime.Now.ToUniversalTime() && DateTime.Now.ToUniversalTime() <= objCuenta.dtFechaCierre)
                        {
                            return objCuenta;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
        /// <summary>
        /// Metodo para encriptar la contraseña ingresada
        /// </summary>
        /// <param name="Texto">Contraseña a encriptar</param>
        /// <returns>contraseña encriptada</returns>
        public static string EncriptarContrasena(string Texto)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] inputBytes = (new UnicodeEncoding()).GetBytes(Texto);
            byte[] hash = sha1.ComputeHash(inputBytes);
            return Convert.ToBase64String(hash);
        }
        /// <summary>
        /// Metodo para comprocar si ya existe un nombre de usuario.
        /// </summary>
        /// <param name="Usuario">usuaruio a promprobar</param>
        /// <returns>si el uxuario existe o no</returns>
        public bool ComprobarUsuario(string Usuario)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (dc.Cuentas.Any(p => p.Usuario == Usuario))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// Valida el estado de la cuenta y si es correcto la activa.
        /// </summary>
        /// <param name="Usuario">usuaruio a promprobar</param>
        /// <returns>si el uxuario existe o no</returns>
        public bool ComprobarActivacionCuenta(long Cuenta, int CodigoDeActivacion)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (dc.Cuentas.Any(p => p.Id == Cuenta && p.CodigoDeActivacion == CodigoDeActivacion && p.EstadoDeActivacion == false))
                {
                    Cuentas objCuenta = dc.Cuentas.Single(p => p.Id == Cuenta && p.CodigoDeActivacion == CodigoDeActivacion && p.EstadoDeActivacion == false);
                    objCuenta.EstadoDeActivacion = true;
                    dc.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// consulta el correo electronico de un miembro por usuario.
        /// </summary>
        /// <param name="Usuario">usuario del miembro al cual se consultara el correo</param>
        /// <returns>objeto miembro</returns>
        public Miembro TomarCorreoElectronico(string Usuario)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (dc.Cuentas.Any(p => p.Usuario == Usuario))
                {
                    if (dc.Miembro.Any(j => j.Id == dc.Cuentas.Single(p => p.Usuario == Usuario).Id_Miembro && j.Email != String.Empty))
                    {
                        return dc.Miembro.Single(j => j.Id == dc.Cuentas.Single(p => p.Usuario == Usuario).Id_Miembro && j.Email != String.Empty);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// Metodo que crea una contraseña proviional a una cuenta por usuario  
        /// </summary>
        /// <param name="Usuario">usuario al que se le creara la pas provicional</param>
        /// <returns>Contrasena provicional</returns>
        public string CreacionDeContrasenaProvicional(string Usuario)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (dc.Cuentas.Any(p => p.Usuario == Usuario))
                {
                    Cuentas objCuenta = dc.Cuentas.Single(p => p.Usuario == Usuario);
                    string ContrasenaAleatoria = GenerarStringAleatorio(20);
                    objCuenta.ContrasenaProvisional = EncriptarContrasena(ContrasenaAleatoria);
                    dc.SubmitChanges();
                    return ContrasenaAleatoria;
                }
                else
                {
                    return String.Empty;
                }
            }
        }
        /// <summary>
        /// metodo que genera un string aleatorio 
        /// </summary>
        /// <param name="Longitud">longitud del string a generar</param>
        /// <returns>string</returns>
        public string GenerarStringAleatorio(int Longitud)
        {
            char[] elementos = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'ñ', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            string Cadena = String.Empty;
            Random objRand = new Random();
            for (int i = 0; i < Longitud; i++)
            {
                Cadena += elementos[objRand.Next(0, elementos.Length - 1)];
            }
            return Cadena;
        }
        /// <summary>
        /// Metodo que cambia la contraseña de un usuario.
        /// </summary>
        /// <param name="Id_Cuenta">identificado de la cuenta que aplica el cambio de contrasena</param>
        /// <param name="Antiguo">antigua contrasena</param>
        /// <param name="Nuevo">nueva contrasena</param>
        /// <returns>verdadero si se cambio bien y falso si no</returns>
        public bool CambioContrasena(long Id_Cuenta, string Antiguo, string Nuevo)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                if (dc.Cuentas.Any(p => p.Id == Id_Cuenta && p.Contrasena == EncriptarContrasena(Antiguo)))
                {
                    Cuentas objCuentas = dc.Cuentas.Single(p => p.Id == Id_Cuenta && p.Contrasena == EncriptarContrasena(Antiguo));
                    objCuentas.Contrasena = EncriptarContrasena(Nuevo);
                    dc.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<LP_Usuarios_X_Cuentas_RolResult> CuentasXRolesXMiembro(long? id_GrupoDeMiembros, string nombreDeUsuario)
        {
            using (ModeloDataContext dc = new ModeloDataContext())
            {
                return dc.LP_Usuarios_X_Cuentas_Rol(id_GrupoDeMiembros, nombreDeUsuario).ToList();
            }
        }
    }
}