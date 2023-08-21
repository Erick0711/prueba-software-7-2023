import { Component } from '@angular/core';
import { Usuarios } from '../entidades/usuarios';
import { UsuarioService } from '../servicios-backend/usuario/usuario.service';
import { HttpResponse } from '@angular/common/http';
@Component({
  selector: 'app-tab1',
  templateUrl: 'tab1.page.html',
  styleUrls: ['tab1.page.scss']
})
export class Tab1Page {
  public nombreCompleto = "";
  public userName = "";
  public password = "";

  public listaUsuarios: Usuarios[] = [];

  constructor(private usuarioService: UsuarioService) {

    // let usuario: Usuarios = new Usuarios();
    // usuario.nombreCompleto = "Maicol erick";
    // usuario.userName = "maicolarteaga0711@gmail.com";
    // usuario.password = "123";

    // this.listaUsuarios.push(usuario);
    this.getUsuarios();
  }

  public addUsuario(){

  }

  public getUsuarios(){
    this.usuarioService.GetUsuarios().subscribe({
      next: (response: HttpResponse<any>) => {
        this.listaUsuarios = response.body;
      },
      error: (error: any) => {
        console.log(error);
      },
      complete: () => {
        
      }
    })
  }
}
