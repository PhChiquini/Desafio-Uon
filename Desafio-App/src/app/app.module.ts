import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule, NgbModalModule } from '@ng-bootstrap/ng-bootstrap';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegistroComponent } from 'src/components/registro/registro.component';
import { ValoresComponent } from 'src/components/valores/valores.component';
import { InicioComponent } from 'src/components/inicio/inicio.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DateTimeFormatPipe } from 'src/_helps/DateTimeFormat.pipe';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxMaskModule, IConfig } from 'ngx-mask';

export const options: Partial<IConfig> | (() => Partial<IConfig>) = '';

@NgModule({
   declarations: [
      AppComponent,
      ValoresComponent,
      RegistroComponent,
      InicioComponent,
      DateTimeFormatPipe
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      NgbModule,
      HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
      NgbModalModule,
      ModalModule.forRoot(),
      BsDatepickerModule.forRoot(),
      BrowserAnimationsModule,
      BsDatepickerModule.forRoot(),
      NgxMaskModule.forRoot(options)
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
