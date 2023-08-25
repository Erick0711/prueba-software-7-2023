describe("CRUD Productos", () => {//Titulo
    //Antes que nada, abrir el navegador en el proyecto Frontend que es el puerto 8100
    beforeEach(() => {
        cy.visit("http://localhost:4200/"); //Frontend de Produccion
    });

    //Servicio API - GetUsuarios()
    it("getProducto()", () => {
        cy.wait(1000);//Esperar 1 seg.
        cy.get("ion-tab-button").eq(0).click(); // click en el TAB de Usuarios
        cy.wait(1000);//Esperar 1 seg.

        cy.get("ion-item").should("be.visible")
        .should("not.have.length", "0"); //Verifica que exista al menos un (ion-item)
    });

    it("addProducto(entidad)", () => {
        cy.get("ion-tab-button").eq(2).click(); // Click en el TAB de Usuarios
        cy.wait(100); // Esperar 1 segundo

        // // Llenar el campo de Nombre Completo
        cy.get("#nombreProducto")
            .type("producto cypress", {  delay: 100  })
            .should("have.value", "producto cypress");

            cy.wait(500); // Esperar medio segundo

            let almacenarNumero = 0;
            const numeroAleatorio = Math.floor(Math.random() * 12) + 1;
            almacenarNumero = numeroAleatorio;
            cy.wait(500); // Esperar medio segundo
            
            cy.get("#idCategoria")
            .type(numeroAleatorio.toString(), { delay: 100})
            .should("have.value", almacenarNumero.toString());
            cy.wait(500); // Esperar medio segundo

        // Hacer clic en el botón "Agregar Usuario"
        cy.get("#addProducto").not("[disabled]").click();
    });
});