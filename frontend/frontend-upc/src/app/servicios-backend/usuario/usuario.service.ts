import { Injectable } from '@angular/core';
import {HttpClient, HttpResponse} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Usuarios } from 'src/app/entidades/usuarios';
@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  PORT = 5062;

  PATH_BACKEND = `http://localhost:${this.PORT}`;

  URL_GET = `${this.PATH_BACKEND}/api/Usuario/GetAllUser`;
  URL_ADD_USUARIO = `${this.PATH_BACKEND}/api/Usuario/AddUser`;
  // URL_ADD_USUARIO = `${this.PATH_BACKEND}/api/Usuario/AddUser`;


  constructor(private httpClient: HttpClient) { }

  public GetUsuarios(): Observable<HttpResponse<any>>
  {
    return this.httpClient
    .get<any>(this.URL_GET,
    {observe: 'response'})
    .pipe();
  }

  public AddUsuario(entidad: Usuarios): Observable<HttpResponse<any>> {
    return this.httpClient
      .post<any>(this.URL_ADD_USUARIO, entidad,
        { observe: 'response' })
      .pipe();
  }
}
