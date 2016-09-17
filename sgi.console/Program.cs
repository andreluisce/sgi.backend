using System;
using Microsoft.Practices.Unity;
using System.Globalization;
using System.Threading;
using sgi.startup;
using sgi.domain.Contracts.Services;
using System.Collections.Generic;
using sgi.domain.Models;

namespace sgi.console
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo ci = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            var container = new UnityContainer();

            DependencyResolver.Resolve(container);
            
            #region UserService
            var service = container.Resolve<IUserService>();
            try
            {
                service.Register("André Evangelista", "andreluisce@gmail.com", "123456", "123456");

                Console.WriteLine("Usuário Cadastrado com Sucesso!");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
                service.Dispose();
            } 
            #endregion
           

            #region RoleService
           // var roleService = container.Resolve<IRoleService>();
          //  var permissionService = container.Resolve<IPermissionService>();
            try
            {
                //roleService.Register("Administradors");
                //roleService.ChangeName("Administradors", "Administrador");

               //var roles = new List<Role>();

                //var role = roleService.GetByName("Administrador");  
               //roles.Add(role);

               //permissionService.Register("PERM_CREATE_NEW_ROLE", roles);


             // var roles =  roleService.GetAll();

              //var perm = permissionService.GetAll();

                Console.WriteLine("Usuário Cadastrado com Sucesso!");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
               // roleService.Dispose();
            }
            #endregion
        }
    }
}
