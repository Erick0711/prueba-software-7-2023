describe("CRUD CategoriaProducto", () => {//Titulo
    //Antes que nada, abrir el navegador en el proyecto Frontend que es el puerto 8100
    beforeEach(() => {
        cy.visit("http://localhost:4200/"); //Frontend de Produccion
    });

    //Servicio API - GetUsuarios()
    it("GetUsuarios()", () => {
        cy.wait(1000);//Esperar 1 seg.
        cy.get("ion-tab-button").eq(0).click(); // click en el TAB de Usuarios
        cy.wait(1000);//Esperar 1 seg.

        cy.get("ion-item").should("be.visible")
        .should("not.have.length", "0"); //Verifica que exista al menos un (ion-item)
    });

    it("AddUser(entidad)", () => {
        cy.get("ion-tab-button").eq(0).click(); // Click en el TAB de Usuarios
        cy.wait(100); // Esperar 1 segundo

        // // Llenar el campo de Nombre Completo
        cy.get("#nombreCompleto")
            .type("insertar nombreCompleto cypress", {  delay: 100  })
            .should("have.value", "insertar nombreCompleto cypress");

        cy.wait(500); // Esperar medio segundo

        // Llenar el campo de Usuario
        cy.get("ion-input[placeholder='Usuario: *']")
            .type("insertar userName cypress", { delay: 100 })
            .should("have.value", "insertar userName cypress");

        cy.wait(500); // Esperar medio segundo

        // Llenar el campo de Contraseña
        cy.get("ion-input[placeholder='Contraseña:*']")
            .type("insertar password cypress", { delay: 100 })
            .should("have.value", "insertar password cypress");

        cy.wait(500); // Esperar medio segundo

        // Hacer clic en el botón "Agregar Usuario"
        cy.get("#addUser").not("[disabled]").click();
    });
});