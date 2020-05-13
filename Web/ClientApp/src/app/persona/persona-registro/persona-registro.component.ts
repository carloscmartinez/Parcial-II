import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
//import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { Persona } from '../models/persona';
import { PersonaService } from 'src/app/services/persona.service';

@Component({
  selector: 'app-persona-registro',
  templateUrl: './persona-registro.component.html',
  styleUrls: ['./persona-registro.component.css']
})
export class PersonaRegistroComponent implements OnInit {
  formGroup: FormGroup;
  persona: Persona;
  submitted= false;
  constructor(
    private personaService: PersonaService,
    private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.buildForm();
  }
  private buildForm() {
        this.persona = new Persona();
        this.persona.personaId= '';
        this.persona.nombre = '';
        this.persona.apellidos= '';
        this.persona.sexo = '';
        this.persona.edad = 0;
        this.persona.departamento = '';
        this.persona.ciudad = '';
        
        this.formGroup = this.formBuilder.group({
          personaId: [this.persona.personaId, Validators.required],
          nombre: [this.persona.nombre, Validators.required],
          apellidos: [this.persona.apellidos, Validators.required],
          sexo: [this.persona.sexo, Validators.required],
          edad: [this.persona.edad, Validators.required],
          departamento: [this.persona.departamento, Validators.required],
          ciudad: [this.persona.ciudad, Validators.required]
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
      /* this.persona= this.formGroup.value;
      this.personaService.post(this.persona).subscribe(p => {
        if (p != null) {
          // const messageBox = this.modalService.open(AlertModalComponent)
          // messageBox.componentInstance.title = "Resultado Operación";
          // messageBox.componentInstance.message = 'Cliente Registrado!!! :-)';
  
          alert('Persona Registrada!');
          //this.persona=p;
          //
        } */
      // });
      
    }

}
