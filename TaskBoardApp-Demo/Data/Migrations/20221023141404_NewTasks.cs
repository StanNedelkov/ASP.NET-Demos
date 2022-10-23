using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp_Demo.Data.Migrations
{
    public partial class NewTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "424873c8-dbb7-4751-baa5-8905333f9ec4");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ea313616-9de2-4a0f-a69f-daca4a3679d2", 0, "36797f10-e2ab-428a-bee6-659fee1ccc65", "guest@gmail.com", false, "Guest", "User", false, null, "GUEST@GMAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEGsIB3QVWDbvrGLYsRVWe3M614Rtgjr7PqqWCZcSZPSib3C4hlTztCnfNtAxO1YByQ==", null, false, "423c5840-b071-458d-9f06-79d1cff8ea17", false, "Guest" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 10, 22, 17, 14, 4, 227, DateTimeKind.Local).AddTicks(4254), "ea313616-9de2-4a0f-a69f-daca4a3679d2" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 10, 13, 17, 14, 4, 227, DateTimeKind.Local).AddTicks(4290), "ea313616-9de2-4a0f-a69f-daca4a3679d2" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 8, 23, 17, 14, 4, 227, DateTimeKind.Local).AddTicks(4293), "ea313616-9de2-4a0f-a69f-daca4a3679d2" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2021, 10, 23, 17, 14, 4, 227, DateTimeKind.Local).AddTicks(4297), "ea313616-9de2-4a0f-a69f-daca4a3679d2" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 5, 2, new DateTime(2021, 10, 23, 17, 14, 4, 227, DateTimeKind.Local).AddTicks(4300), "Make new tasks in different status", "ea313616-9de2-4a0f-a69f-daca4a3679d2", "Check if DB works correctly" },
                    { 6, 3, new DateTime(2021, 10, 23, 17, 14, 4, 227, DateTimeKind.Local).AddTicks(4303), "Make new tasks in different status", "ea313616-9de2-4a0f-a69f-daca4a3679d2", "Check if DB works correctly 2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ea313616-9de2-4a0f-a69f-daca4a3679d2");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "424873c8-dbb7-4751-baa5-8905333f9ec4", 0, "976b1c12-bf44-437f-92a0-5689544d158f", "guest@gmail.com", false, "Guest", "User", false, null, "GUEST@GMAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEML45ZEni9o5+XnYmkLTiEJyUWcaUrbfoVMH4WwMbnV94D/qMRFG3uSHgIPykfQECA==", null, false, "60cd6980-e92d-4595-bef8-54efb3e2c2ec", false, "Guest" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 10, 20, 15, 56, 3, 726, DateTimeKind.Local).AddTicks(1151), "424873c8-dbb7-4751-baa5-8905333f9ec4" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 10, 11, 15, 56, 3, 726, DateTimeKind.Local).AddTicks(1180), "424873c8-dbb7-4751-baa5-8905333f9ec4" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 8, 21, 15, 56, 3, 726, DateTimeKind.Local).AddTicks(1182), "424873c8-dbb7-4751-baa5-8905333f9ec4" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2021, 10, 21, 15, 56, 3, 726, DateTimeKind.Local).AddTicks(1186), "424873c8-dbb7-4751-baa5-8905333f9ec4" });
        }
    }
}
