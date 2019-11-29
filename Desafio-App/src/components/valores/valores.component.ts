import { Component, OnInit } from '@angular/core';
import { DesafioService } from 'src/services/desafio.service';
import { Valores } from 'src/models/valores';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-valores',
  templateUrl: './valores.component.html',
  styleUrls: ['./valores.component.css']
})

export class ValoresComponent implements OnInit {

  valor: Valores;
  valores: Valores[];
  vl1: number;
  vl2: number;
  formValores: FormGroup;
  pageSize = 4;
  page = 1;

  constructor(
    private desafioService: DesafioService,
    private fb: FormBuilder,
    private modalService: NgbModal
  ) { }

  ngOnInit() {
    this.getValores();
    this.validate();
  }

  openModal(content: any) {
    this.modalService.open(content);
  }

  validate() {
    this.formValores = this.fb.group({
      valor1: ['', [Validators.required, Validators.max(10000), Validators.min(-10000)]],
      valor2: ['', [Validators.required, Validators.max(10000), Validators.min(-10000)]]
    });
  }

  getValores() {
    this.desafioService.getValores().subscribe(
      (val: Valores[]) => {
        this.valores = val;
        console.log(this.valores);
      }, error => {
        console.log(error);
      }
    );
  }

  calcular(op: string) {

    this.valor = Object.assign(
      {operacao: op},
      this.formValores.value);

    this.valor.resultado = 0;

    this.desafioService.calcular(this.valor).subscribe(
      () => {
        this.getValores();
      }, error => {
        console.log(error);
      }
    );
  }

}
