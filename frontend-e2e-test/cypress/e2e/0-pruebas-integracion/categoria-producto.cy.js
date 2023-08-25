describe("CRUD CategoriaProducto", () => {//Titulo
    //Antes que nada, abrir el navegador en el proyecto Frontend que es el puerto 8100
    beforeEach(() => {
        cy.visit("http://localhost:4200/"); //Frontend de Produccion
    });

    //Servicio API - GetUsuarios()
    it("GetCategoriaProducto()", () => {
        cy.wait(1000);//Esperar 1 seg.
        cy.get("ion-tab-button").eq(0).click(); // click en el TAB de categoria producto
        cy.wait(1000);//Esperar 1 seg.

        cy.get("ion-item").should("be.visible")
        .should("not.have.length", "0"); //Verifica que exista al menos un (ion-item)
    });

    it("addCategoria(entidad)", () => {
        cy.get("ion-tab-button").eq(1).click(); // Click en el TAB de Usuarios
        cy.wait(100); // Esperar 1 segundo

        // // Llenar el campo de Nombre Completo
        cy.get("#categoriaProducto")
            .type("Nueva categoria", { delay: 100 })
            .should("have.value", "Nueva categoria");

        cy.wait(500); // Esperar medio segundo

        // Hacer clic en el botón "Agregar Usuario"
        cy.get("#addCategoriaProducto").not("[disabled]").click();
    });
});