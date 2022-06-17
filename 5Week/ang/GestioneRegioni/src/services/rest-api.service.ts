import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { Region } from 'src/models/regions';

@Injectable({
  providedIn: 'root'
})

export class RestApiService {

  baseUrlApi = 'http://localhost:9999';

  constructor(private http: HttpClient) { }

  getRegions(model: any) {
    const urlApi = this.baseUrlApi + '/Api/getAllRegioni';

    return this.http.get(urlApi, model)
    .pipe(map((response: any) => {
      const val = response;
    }));
  }
}
