import { Component } from '@angular/core';
import { Categoria } from '../entidades/categorias';

@Component({
  selector: 'app-tab2',
  templateUrl: 'tab2.page.html',
  styleUrls: ['tab2.page.scss']
})
export class Tab2Page {
  public nombreCategoria = "";
  
  public listaCategoria: Categoria[] = [];
  constructor() {
    let categoria = new Categoria();
    categoria.nombreCategoria = "Nuevo Producto";

    this.listaCategoria.push(categoria);
  }

  public addCategoria(){

  }
}
