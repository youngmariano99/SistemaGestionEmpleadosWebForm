using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaGestionEmpleadosWebForm.models; // Assuming this is the correct namespace for Empleado model

namespace SistemaGestionEmpleadosWebForm
{
    public partial class Default : System.Web.UI.Page
    {

        
        protected void Page_Load(object sender, EventArgs e)
        {
            llenartablas();
            
            
        }
        
        
        

        public void llenartablas()
        {
            if (Session["TablaEmpleados"] == null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Nombre", typeof(string));
                dt.Columns.Add("Apellido", typeof(string));
                dt.Columns.Add("Edad", typeof(int));
                dt.Columns.Add("Departamento", typeof(string));


                dt.Rows.Add(1, "Juan", "Pérez", 30, "Recursos Humanos");
                dt.Rows.Add(2, "Ana", "Gómez", 25, "Finanzas");
                dt.Rows.Add(3, "Luis", "Martínez", 28, "IT");
                dt.Rows.Add(4, "María", "López", 35, "Marketing");
                dt.Rows.Add(5, "Carlos", "Sánchez", 40, "Ventas");
                dt.Rows.Add(6, "Laura", "Torres", 32, "Atención al Cliente");
                dt.Rows.Add(7, "Pedro", "Ramírez", 29, "Logística");
                dt.Rows.Add(8, "Sofía", "Hernández", 27, "Desarrollo de Producto");
                dt.Rows.Add(9, "Javier", "García", 31, "Calidad");
                dt.Rows.Add(10, "Isabel", "Fernández", 26, "Investigación y Desarrollo");
                dt.Rows.Add(11, "Diego", "Castro", 33, "Compras");
                dt.Rows.Add(12, "Clara", "Morales", 34, "Proyectos");
                dt.Rows.Add(13, "Andrés", "Jiménez", 36, "Administración");

                Session["TablaEmpleados"] = dt;
                TablaEmpleados.DataSource = dt;
                TablaEmpleados.DataBind();

            }
            
        }

    public void CrearEmpleado(Empleados empleado)
        {
            
            

            DataTable dt = (DataTable)Session["TablaEmpleados"]; // Recuperamos la tabla
            dt.Rows.Add(empleado.Id, empleado.Nombre, empleado.Apellido, empleado.Edad, empleado.Departamento);
            Session["TablaEmpleados"] = dt; // Volvemos a almacenarla

            TablaEmpleados.DataSource = dt;
            TablaEmpleados.DataBind();

        }

    public void btnCrearEmpleado_Click(object sender, EventArgs e)
        {
            Empleados empleado = new Empleados();
            empleado.Id = int.Parse(txtboxIdCrearEmpleado.Text); // Example ID, in a real application this would be generated dynamically
            empleado.Nombre = txtboxNombreCrearEmpleado.Text;
            empleado.Apellido = txtboxApellidoCrearEmpleado.Text;
            empleado.Edad = int.Parse( txtboxEdadCrearEmpleado.Text);
            empleado.Departamento = txtboxDepartamentoCrearEmpleado.Text;
            CrearEmpleado(empleado);

            txtboxApellidoCrearEmpleado.Text = string.Empty;
            txtboxDepartamentoCrearEmpleado.Text = string.Empty;
            txtboxEdadCrearEmpleado.Text = string.Empty;
            txtboxIdCrearEmpleado.Text = string.Empty;
            txtboxNombreCrearEmpleado.Text = string.Empty;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Empleado creado exitosamente');", true);
        }

        public List<Empleados>  ExtraerRegistros(DataTable dt)
        {
            List<Empleados> listaEmpleados = new List<Empleados>();

            foreach (DataRow row in dt.Rows)
            {
                Empleados empleado = new Empleados()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Nombre = row["Nombre"].ToString(),
                    Apellido = row["Apellido"].ToString(),
                    Edad = Convert.ToInt32(row["Edad"]),
                    Departamento = row["Departamento"].ToString()
                };

                listaEmpleados.Add(empleado);
            }

            return listaEmpleados;
        }

        public void BuscarEmpleado()
        {
            string nombreEmpleado = txtNombreDelEmpladoParaEditar.Text;
            DataTable dt = (DataTable)Session["TablaEmpleados"]; // Recuperamos la tabla
            Empleados empleado = new Empleados();

            foreach (DataRow row in dt.Rows)
            {
                if (row["Nombre"].ToString().ToLower() == nombreEmpleado.ToLower())
                {
                    empleado.Id = Convert.ToInt32(row["Id"]);
                    empleado.Nombre = row["Nombre"].ToString();
                    empleado.Apellido = row["Apellido"].ToString();
                    empleado.Edad = Convert.ToInt32(row["Edad"]);
                    empleado.Departamento = row["Departamento"].ToString();

                    txtboxApellidoEditarEmpleado.Text = empleado.Apellido;
                    txtboxDepartamentoEditarEmpleado.Text = empleado.Departamento;
                    txtboxEdadEditarEmpleado.Text = empleado.Edad.ToString();
                    txtboxIDEditarEmpleado.Text = empleado.Id.ToString();
                    txtboxNombreEditarEmpleado.Text = empleado.Nombre;

                    if (empleado.Id == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Empleado no encontrado');", true);
                    }
                  
                        break;
                }
            }
            
            

        }

        public void EditarEmpleado()
        {
            string nombreEmpleado = txtNombreDelEmpladoParaEditar.Text.ToLower();
            DataTable dt = (DataTable)Session["TablaEmpleados"]; // Recuperamos la tabla

            foreach (DataRow row in dt.Rows)
            {
                if (nombreEmpleado == row["Nombre"].ToString().ToLower())
                {
                    row["Nombre"] = txtboxNombreEditarEmpleado.Text;
                    row["Apellido"] = txtboxApellidoEditarEmpleado.Text;

                    int edad;
                    if (int.TryParse(txtboxEdadEditarEmpleado.Text, out edad))
                    {
                        row["Edad"] = edad;
                    }

                    row["Departamento"] = txtboxDepartamentoEditarEmpleado.Text;

                    break; // Detener el bucle después de encontrar y modificar el empleado
                }
            }

            // Guardamos los cambios en Session solo una vez
            Session["TablaEmpleados"] = dt;

            // Actualizamos la tabla en la interfaz
            TablaEmpleados.DataSource = dt;
            TablaEmpleados.DataBind();
        }

        public void btnBuscarEmpleado_Click(object sender, EventArgs e)
        {
           BuscarEmpleado();

        }
        public void btnEditarEmpleado_Click(object sender, EventArgs e)
        {
            EditarEmpleado();
            txtboxApellidoEditarEmpleado.Text = string.Empty;
            txtboxDepartamentoEditarEmpleado.Text = string.Empty;
            txtboxEdadEditarEmpleado.Text = string.Empty;
            txtboxIDEditarEmpleado.Text = string.Empty;
            txtboxNombreEditarEmpleado.Text = string.Empty;
            txtNombreDelEmpladoParaEditar.Text = string.Empty;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Empleado editado exitosamente');", true);

        }


        public void EliminarEmpleado()
        {
            string nombreEmpleado = txtboxEmpleadoAElminar.Text.ToLower();
            DataTable dt = (DataTable)Session["TablaEmpleados"]; // Recuperamos la tabla
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                if (dt.Rows[i]["Nombre"].ToString().ToLower() == nombreEmpleado)
                {
                    dt.Rows.RemoveAt(i);
                }
            }
            // Guardamos los cambios en Session solo una vez
            Session["TablaEmpleados"] = dt;
            // Actualizamos la tabla en la interfaz
            TablaEmpleados.DataSource = dt;
            TablaEmpleados.DataBind();
        }

        public void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            EliminarEmpleado();
            txtboxEmpleadoAElminar.Text = string.Empty;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Empleado eliminado exitosamente');", true);
        }
    }
}
