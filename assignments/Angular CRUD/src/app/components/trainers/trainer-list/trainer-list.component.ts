import { Component, OnInit } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Trainer } from 'src/app/models/trainer.models';
import { TrainersService } from 'src/app/services/trainers.service';

@Component({
  selector: 'app-trainer-list',
  templateUrl: './trainer-list.component.html',
  styleUrls: ['./trainer-list.component.css']
})
export class TrainerListComponent implements OnInit {
  trainers:Trainer[]=[];
  constructor(private trainerservice:TrainersService){}
  ngOnInit():void{
    this.trainerservice.getAllTrainers()
    .subscribe({
      next:(trainers)=>{
        this.trainers=trainers;
      },
      error:(response)=>{
        console.log(response);
      }
      
      
    })
  }
}
