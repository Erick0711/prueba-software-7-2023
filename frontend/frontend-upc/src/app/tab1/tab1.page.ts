import { Component } from '@angular/core';
import { Usuarios } from '../entidades/usuarios';
import { UsuarioService } from '../servicios-backend/usuario/usuario.service';
import { HttpResponse } from '@angular/common/http';
import { ModalController } from '@ionic/angular';
@Component({
  selector: 'app-tab1',
  templateUrl: 'tab1.page.html',
  styleUrls: ['tab1.page.scss']
})
export class Tab1Page {
  public id = 0;
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

  public addUsuario(){
    this.AddUsuarioFromBackend(this.nombreCompleto, this.userName, this.password)
  }

  private AddUsuarioFromBackend(nombreCompleto: string, userName: string, password: string){

    var usuarioEntidad = new Usuarios();
    usuarioEntidad.nombreCompleto = nombreCompleto;
    usuarioEntidad.userName = userName;
    usuarioEntidad.password = password;

      this.usuarioService.AddUsuario(usuarioEntidad).subscribe({
        next: (response: HttpResponse<any>) => {
            console.log(response.body)//1
            if(response.body == 1){
                alert("Se agrego el USUARIO con exito :)");
                this.getUsuarios();//Se actualize el listado
                this.nombreCompleto = "";
                this.userName = "";
                this.password = "";
            }else{
                alert("Al agregar al USUARIO fallo exito :(");
            }
        },
        error: (error: any) => {
            console.log(error);
        },
        complete: () => {
            console.log('complete - this.AddUsuario()');
        },
    });
  }

  // public editUsuario()
  // {
  //   this.EditUsuarioFromBackend(this.userName, this.password, this.id);
  // }
  // public EditUsuarioFromBackend(userName: string, password: string, id:number,)
  // {
  //   var usuarioEntidad = new Usuarios();
  //   usuarioEntidad.id = id;
  //   usuarioEntidad.userName = userName;
  //   usuarioEntidad.password = password;
  //   if(id > 0){
  //         this.usuarioService.EditUser(usuarioEntidad).subscribe({
  //           next: (response: HttpResponse<any>) => {
  //             if(response.body == 1){
  //                 alert("Usuario editado correctamente :)");
  //                 this.getUsuarios();//Se actualize el listado
  //                 this.nombreCompleto = "";
  //             }else{
  //                 alert("Algo sucedio :(");
  //             }
  //         },
  //         error: (error: any) => {
  //             console.log(error);
  //         },
  //         complete: () => {
  //             console.log('complete - this.editUsuario()');
  //         },
  //     });
  //   }else{
  //     alert('Ingresar un codigo correcto');
  //   }
  // }
}
