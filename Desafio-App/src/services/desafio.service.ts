import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Valores } from 'src/models/valores';
import { Observable } from 'rxjs';
import { Registros } from 'src/models/registros';
import { RegistroComponent } from 'src/components/registro/registro.component';

@Injectable({
    providedIn: 'root'
})
export class DesafioService {

    baseUrl = 'http://localhost:5000/desafio';

constructor(private http: HttpClient) { }

    getValores(): Observable<Valores[]> {
        return this.http.get<Valores[]>(`${this.baseUrl}/getValores`);
    }

    calcular(valores: Valores) {
        return this.http.post(`${this.baseUrl}/postValores`, valores);
    }

    getRegistros(): Observable<Registros[]> {
        return this.http.get<Registros[]>(`${this.baseUrl}/getRegistros`);
    }

    postRegistro(registro: Registros) {
        return this.http.post(`${this.baseUrl}/postRegistros`, registro);
    }

}
