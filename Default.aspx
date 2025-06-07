<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SistemaGestionEmpleadosWebForm.Default" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">

    <!-- HERO -->
    <div class="text-center py-10 bg-blue-600 text-white">
        <h1 class="text-3xl font-bold">Bienvenido al sistema de gestión</h1>
    </div>

    <!-- TABLA DE EMPLEADOS -->
    <div class="max-w-4xl mx-auto mt-8 shadow-lg rounded-lg bg-white p-6">
        <asp:GridView ID="TablaEmpleados" CssClass="w-full border border-gray-300 rounded-lg" runat="server" AutoGenerateColumns="True" />
    </div>

    <!-- CREAR EMPLEADOS -->
    <div class="max-w-xl mx-auto mt-8 p-6 bg-gray-100 rounded-lg shadow-md">
        <h2 class="text-2xl font-semibold text-gray-700 text-center">Crear Empleados</h2>
        <div class="grid gap-4 mt-4">
            <asp:Label ID="labelIdEmpleado" Text="ID" runat="server" CssClass="block text-gray-600 font-medium" />
            <asp:TextBox ID="txtboxIdCrearEmpleado" runat="server" CssClass="w-full border border-gray-300 rounded-lg p-2" />

            <asp:Label ID="labelNombreEmpleado" Text="Nombre" runat="server" CssClass="block text-gray-600 font-medium" />
            <asp:TextBox ID="txtboxNombreCrearEmpleado" runat="server" CssClass="w-full border border-gray-300 rounded-lg p-2" />

            <asp:Label ID="labelApellidoEmpleado" Text="Apellido" runat="server" CssClass="block text-gray-600 font-medium" />
            <asp:TextBox ID="txtboxApellidoCrearEmpleado" runat="server" CssClass="w-full border border-gray-300 rounded-lg p-2" />

            <asp:Label ID="labelEdadEmpleado" Text="Edad" runat="server" CssClass="block text-gray-600 font-medium" />
            <asp:TextBox ID="txtboxEdadCrearEmpleado" runat="server" CssClass="w-full border border-gray-300 rounded-lg p-2" />

            <asp:Label ID="labelDepartamentoEmpleado" Text="Departamento" runat="server" CssClass="block text-gray-600 font-medium" />
            <asp:TextBox ID="txtboxDepartamentoCrearEmpleado" runat="server" CssClass="w-full border border-gray-300 rounded-lg p-2" />

            <asp:Button ID="btnCrearEmpleado" Text="Crear Empleado" runat="server" OnClick="btnCrearEmpleado_Click" CssClass="w-full bg-blue-500 text-white py-2 rounded-lg hover:bg-blue-600 transition duration-200"  />
        </div>
    </div>

    <!-- EDITAR EMPLEADOS -->
    <div class="max-w-xl mx-auto mt-8 p-6 bg-gray-100 rounded-lg shadow-md">
        <h2 class="text-2xl font-semibold text-gray-700 text-center">Editar Empleados</h2>
        <div class="grid gap-4 mt-4">
            <asp:Label ID="lblNombreBuscarEmpleado" Text="Coloque el nombre del empleado" runat="server" CssClass="block text-gray-600 font-medium" />
            <asp:TextBox ID="txtNombreDelEmpladoParaEditar" runat="server" CssClass="w-full border border-gray-300 rounded-lg p-2" />

            <asp:Label ID="lblIDEditarEmpleado" Text="ID" runat="server" CssClass="block text-gray-600 font-medium" />
            <asp:TextBox ID="txtboxIDEditarEmpleado" runat="server" CssClass="w-full border border-gray-300 rounded-lg p-2" />

            <asp:Label ID="lblNombreEditarEmpleado" Text="Nombre" runat="server" CssClass="block text-gray-600 font-medium" />
            <asp:TextBox ID="txtboxNombreEditarEmpleado" runat="server" CssClass="w-full border border-gray-300 rounded-lg p-2" />

            <asp:Label ID="lblApellidEditarEmpleado" Text="Apellido" runat="server" CssClass="block text-gray-600 font-medium" />
            <asp:TextBox ID="txtboxApellidoEditarEmpleado" runat="server" CssClass="w-full border border-gray-300 rounded-lg p-2" />

            <asp:Label ID="lblEdadEditarEmpleado" Text="Edad" runat="server" CssClass="block text-gray-600 font-medium" />
            <asp:TextBox ID="txtboxEdadEditarEmpleado" runat="server" CssClass="w-full border border-gray-300 rounded-lg p-2" />

            <asp:Label ID="lblDepartamentoEditarEmpleado" Text="Departamento" runat="server" CssClass="block text-gray-600 font-medium" />
            <asp:TextBox ID="txtboxDepartamentoEditarEmpleado" runat="server" CssClass="w-full border border-gray-300 rounded-lg p-2" />

            <asp:Button ID="btnBuscrempleado" Text="Buscar Empleado" runat="server" OnClick="btnBuscarEmpleado_Click" CssClass="w-full bg-yellow-500 text-white py-2 rounded-lg hover:bg-yellow-600 transition duration-200" />
            <asp:Button ID="btnEditarEmpleado" Text="Editar Empleado" runat="server" OnClick="btnEditarEmpleado_Click" CssClass="w-full bg-blue-500 text-white py-2 rounded-lg hover:bg-blue-600 transition duration-200" />
        </div>
    </div>

    <!-- ELIMINAR EMPLEADOS -->
    <div class="max-w-xl mx-auto mt-8 p-6 bg-gray-100 rounded-lg shadow-md">
        <h2 class="text-2xl font-semibold text-gray-700 text-center">Eliminar Empleados</h2>
        <div class="grid gap-4 mt-4">
            <asp:Label ID="lblBuscarEmpleadoEliminar" Text="Coloque el nombre del empleado" runat="server" CssClass="block text-gray-600 font-medium" />
            <asp:TextBox ID="txtboxEmpleadoAElminar" runat="server" CssClass="w-full border border-gray-300 rounded-lg p-2" />

            <asp:Button ID="btnEliminarEmpleado" Text="Eliminar Empleado" runat="server" OnClick="btnEliminarEmpleado_Click" CssClass="w-full bg-red-500 text-white py-2 rounded-lg hover:bg-red-600 transition duration-200" />
        </div>
    </div>

</asp:Content>