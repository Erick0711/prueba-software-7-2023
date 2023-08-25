import { Injectable } from '@angular/core';
import {HttpClient, HttpResponse} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Productos } from 'src/app/entidades/productos';

@Injectable({
  providedIn: 'root'
})

export class ProductoService {
  PORT = 5062;

  PATH_BACKEND = `http://localhost:${this.PORT}`;

  URL_GET = `${this.PATH_BACKEND}/api/Producto/GetAllProducto`;
  URL_ADD_PRODUCTO = `${this.PATH_BACKEND}/api/Producto/AddProducto`;
  // URL_ADD_USUARIO = `${this.PATH_BACKEND}/api/Usuario/AddUser`;


  constructor(private httpClient: HttpClient) { }

  public GetProductos(): Observable<HttpResponse<any>>
  {
    return this.httpClient
    .get<any>(this.URL_GET,
    {observe: 'response'})
    .pipe();
  }

  public AddProducto(entidad: Productos): Observable<HttpResponse<any>> {
    return this.httpClient
      .post<any>(this.URL_ADD_PRODUCTO, entidad,
        { observe: 'response' })
      .pipe();
  }
}
