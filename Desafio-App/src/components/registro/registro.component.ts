import { Component, OnInit, ViewEncapsulation, ViewChild } from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { Registros } from 'src/models/registros';
import { ModalDirective } from 'ngx-bootstrap/modal/ngx-bootstrap-modal';
import { DesafioService } from 'src/services/desafio.service';
import { BsLocaleService, BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { listLocales } from 'ngx-bootstrap/chronos';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  encapsulation: ViewEncapsulation.None,
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent implements OnInit {

  // *ngIf="registros && registros.length"

  registros: Registros[];
  registro: Registros;
  registerForm: FormGroup;
  @ViewChild('autoShownModal', { static: false }) autoShownModal: ModalDirective;
  isModalShown = true;
  maxDate: Date;
  pageSize = 9;
  page = 1;

  constructor(
    private fb: FormBuilder,
    private desafioService: DesafioService,
    private localeService: BsLocaleService
  ) {
    this.maxDate = new Date();
    this.maxDate.setDate(this.maxDate.getDate());
  }

  showModal(): void {
    this.isModalShown = true;
  }

  hideModal(): void {
    this.autoShownModal.hide();
  }

  onHidden(): void {
    this.isModalShown = false;
  }

  ngOnInit() {
    this.getRegistro();
    this.validate();
  }

  getRegistro() {
    this.desafioService.getRegistros().subscribe(
      (registro) => {
        this.registros = registro;
        console.log(registro);
        console.log(this.registros);
      }, error => {
        console.log(error);
      }
    );
  }

  saveRegistro() {

    this.hideModal();

    this.registro = Object.assign({}, this.registerForm.value);

    this.desafioService.postRegistro(this.registro).subscribe(
      () => {
        this.getRegistro();
      }, error => {
        console.log(error);
      }
    );
  }

  validate() {
    this.registerForm = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      endereco: ['', Validators.required],
      dataNascimento: ['', Validators.required],
      telefone: ['', Validators.required],
      identificacao: ['', Validators.required]
    });
  }

}
