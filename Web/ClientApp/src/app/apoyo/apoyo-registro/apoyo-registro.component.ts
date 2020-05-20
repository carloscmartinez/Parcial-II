import { Component, OnInit } from '@angular/core';
import { ApoyoService } from 'src/app/services/apoyo.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Apoyo } from '../models/apoyo';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';

@Component({
  selector: 'app-apoyo-registro',
  templateUrl: './apoyo-registro.component.html',
  styleUrls: ['./apoyo-registro.component.css']
})
export class ApoyoRegistroComponent implements OnInit {
  formGroup: FormGroup;
  apoyo: Apoyo;
 submitted= false;
  constructor(
    private formBuilder: FormBuilder,
    private modalService: NgbModal,
    private apoyoService: ApoyoService
    ) { }

  ngOnInit() {
     this.buildForm();
    
  }
  private buildForm() {
        this.apoyo= new Apoyo();
    let myDate = new Date();
        this.apoyo.apoyoId= 0;
        this.apoyo.valor= 0;
        this.apoyo.modalidad= '';
        this.apoyo.fecha= myDate;
       
        
        this.formGroup = this.formBuilder.group({
          apoyoId: [this.apoyo.apoyoId, Validators.required],
          valor: [this.apoyo.valor, Validators.required],
          modalidad: [this.apoyo.modalidad, Validators.required],
          fecha: [this.apoyo.fecha, Validators.required]
        });
      }
    get control() { 
      return this.formGroup.controls;
    }
    // onResetForm(){
    //   this.formGroup.reset();
    // }
    onSubmit() {
      this.submitted = true;
       if (this.formGroup.invalid) {
          return;
       }
       this.add();
       this.formGroup.reset();
    }
    add() {
       this.apoyo= this.formGroup.value;
      this.apoyoService.post(this.apoyo).subscribe(p => {
        if (p != null) {
          const messageBox = this.modalService.open(AlertModalComponent)
          messageBox.componentInstance.title = "Resultado Operación";
          messageBox.componentInstance.message = 'Cliente Registrado!!! :-)';    
          this.apoyo=p;

        } 
       });
      
    }

 
}
