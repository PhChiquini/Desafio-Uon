/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { DesafioService } from './desafio.service';

describe('Service: Desafio', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DesafioService]
    });
  });

  it('should ...', inject([DesafioService], (service: DesafioService) => {
    expect(service).toBeTruthy();
  }));
});
