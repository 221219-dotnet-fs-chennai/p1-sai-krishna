import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Trainer } from 'src/app/models/trainer.models';
import { TrainersService } from 'src/app/services/trainers.service';

@Component({
  selector: 'app-add-trainer',
  templateUrl: './add-trainer.component.html',
  styleUrls: ['./add-trainer.component.css']
})
export class AddTrainerComponent implements OnInit {
  addTrainerReq:Trainer={
    id:0,
    name:'',
    email:'',
    password:'',
    phoneNo:'',
    city:'',
    state:'',
    gender:'',
    pincode:'',
    aboutMe:''
   };
  
  constructor(private trainerservice:TrainersService, private router:Router){}
  ngOnInit(): void {
    
  }
  addtrainerfunc(){
    this.trainerservice.addTrainer(this.addTrainerReq)
    .subscribe({
      next:(trainer)=>{
        console.log(trainer);
        this.router.navigate(['/trainers']);
      }
    })
  }
}
