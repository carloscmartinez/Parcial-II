import { Component, OnInit } from '@angular/core';
import { ApoyoService } from 'src/app/services/apoyo.service';
import { Apoyo } from '../models/apoyo';

@Component({
  selector: 'app-apoyo-consulta',
  templateUrl: './apoyo-consulta.component.html',
  styleUrls: ['./apoyo-consulta.component.css']
})
export class ApoyoConsultaComponent implements OnInit {
  apoyos: Apoyo[];
  constructor(private apoyoService: ApoyoService) { }

  ngOnInit() {
    this.apoyoService.get().subscribe(result => {
      this.apoyos = result;
    });
  }

}
