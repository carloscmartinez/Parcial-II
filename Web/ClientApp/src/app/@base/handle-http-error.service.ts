import { Injectable } from '@angular/core';
import { of, Observable } from 'rxjs';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
//import { AlertModalComponent } from './alert-modal/alert-modal.component';

@Injectable({
  providedIn: 'root'
})
export class HandleHttpErrorService {

  constructor() { }
  
  public handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      console.error(error);

      return of(result as T);
    };
  }
  public log(message: string) {
    console.log(message);
  }
  
}

