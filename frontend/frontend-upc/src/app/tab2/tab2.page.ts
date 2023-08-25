import { Component } from '@angular/core';
import { Categorias } from '../entidades/categorias';
import { CategoriaProductoService } from '../servicios-backend/categoria-producto/categoria-producto.service';
import { HttpResponse } from '@angular/common/http';
@Component({
  selector: 'app-tab2',
  templateUrl: 'tab2.page.html',
  styleUrls: ['tab2.page.scss']
})

export class Tab2Page {
  public nombre = "";
  
  public listaCategorias: Categorias[] = [];
  
  constructor(private categoriaProductoService: CategoriaProductoService) {
    // let categoria = new Categoria();
    // categoria.nombreCategoria = "Nuevo Producto";

    // this.listaCategoria.push(categoria);
    this.getCategoriaProducto();
  }

  public getCategoriaProducto(){
    this.categoriaProductoService.GetCategoriaProducto().subscribe({
      next: (response: HttpResponse<any>) => {
        this.listaCategorias = response.body;
        console.log(this.listaCategorias);
      },
      error: (error: any) => {
        console.log(error);
      },
      complete: () => {
        
      }
    })
  }


  public addCategoria(){
    this.AddUCategoriaProductoFromBackend(this.nombre);
  }

  private AddUCategoriaProductoFromBackend(nombre: string){

    var categoriaEntidad = new Categorias();
    categoriaEntidad.nombre = nombre;

      this.categoriaProductoService.AddCategoriaProducto(categoriaEntidad).subscribe({
        next: (response: HttpResponse<any>) => {
            console.log(response.body)//1
            if(response.body == 1){
                alert("Se agrego la categoria con exito :)");
                this.getCategoriaProducto();//Se actualize el listado
                this.nombre = "";
            }else{
                alert("Al agregar la categoria fallo exito :(");
            }
        },
        error: (error: any) => {
            console.log(error);
        },
        complete: () => {
            console.log('complete - this.AddCategoriaProducto()');
        },
    });
  }
}
