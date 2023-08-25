import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Categorias } from 'src/app/entidades/categorias';
@Injectable({
  providedIn: 'root'
})
export class CategoriaProductoService {

  PORT = 5062;

  PATH_BACKEND = `http://localhost:${this.PORT}`;

  URL_GET = `${this.PATH_BACKEND}/api/CategoriaProducto/GetAllCategoriaProducto`;
  URL_ADD_CATEGORIA = `${this.PATH_BACKEND}/api/CategoriaProducto/AddCategoriaProducto`;
  constructor(private httpClient: HttpClient) { }

  public GetCategoriaProducto(): Observable<HttpResponse<any>>
  {
    return this.httpClient
    .get<any>(this.URL_GET,
    {observe: 'response'})
    .pipe();
  }

  public AddCategoriaProducto(entidad: Categorias): Observable<HttpResponse<any>> {
    return this.httpClient
      .post<any>(this.URL_ADD_CATEGORIA, entidad,
        { observe: 'response' })
      .pipe();
  }
}
