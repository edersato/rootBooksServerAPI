using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rootBooks.Migrations
{
    /// <inheritdoc />
    public partial class MigrationCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_ClienteId",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Produtos_ProdutoId",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "ValorUntVenda",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "ValorVenda",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "ValorUnt",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "QtdVenda",
                table: "Vendas",
                newName: "qtdVenda");

            migrationBuilder.RenameColumn(
                name: "IdProduto",
                table: "Vendas",
                newName: "idProduto");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "Vendas",
                newName: "ProdutoidProduto");

            migrationBuilder.RenameColumn(
                name: "DataVenda",
                table: "Vendas",
                newName: "dthVenda");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Vendas",
                newName: "ClienteIdCliente");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Vendas",
                newName: "idVenda");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_ProdutoId",
                table: "Vendas",
                newName: "IX_Vendas_ProdutoidProduto");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_ClienteId",
                table: "Vendas",
                newName: "IX_Vendas_ClienteIdCliente");

            migrationBuilder.RenameColumn(
                name: "DescProduto",
                table: "Produtos",
                newName: "dscProduto");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Produtos",
                newName: "idProduto");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clientes",
                newName: "IdCliente");

            migrationBuilder.AddColumn<decimal>(
                name: "vlrUnitarioVenda",
                table: "Vendas",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "vlrUnitario",
                table: "Produtos",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nmCliente",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_ClienteIdCliente",
                table: "Vendas",
                column: "ClienteIdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Produtos_ProdutoidProduto",
                table: "Vendas",
                column: "ProdutoidProduto",
                principalTable: "Produtos",
                principalColumn: "idProduto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_ClienteIdCliente",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Produtos_ProdutoidProduto",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "vlrUnitarioVenda",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "vlrUnitario",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "nmCliente",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "qtdVenda",
                table: "Vendas",
                newName: "QtdVenda");

            migrationBuilder.RenameColumn(
                name: "idProduto",
                table: "Vendas",
                newName: "IdProduto");

            migrationBuilder.RenameColumn(
                name: "dthVenda",
                table: "Vendas",
                newName: "DataVenda");

            migrationBuilder.RenameColumn(
                name: "ProdutoidProduto",
                table: "Vendas",
                newName: "ProdutoId");

            migrationBuilder.RenameColumn(
                name: "ClienteIdCliente",
                table: "Vendas",
                newName: "ClienteId");

            migrationBuilder.RenameColumn(
                name: "idVenda",
                table: "Vendas",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_ProdutoidProduto",
                table: "Vendas",
                newName: "IX_Vendas_ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendas_ClienteIdCliente",
                table: "Vendas",
                newName: "IX_Vendas_ClienteId");

            migrationBuilder.RenameColumn(
                name: "dscProduto",
                table: "Produtos",
                newName: "DescProduto");

            migrationBuilder.RenameColumn(
                name: "idProduto",
                table: "Produtos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdCliente",
                table: "Clientes",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "ValorUntVenda",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "ValorVenda",
                table: "Vendas",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ValorUnt",
                table: "Produtos",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_ClienteId",
                table: "Vendas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Produtos_ProdutoId",
                table: "Vendas",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id");
        }
    }
}
