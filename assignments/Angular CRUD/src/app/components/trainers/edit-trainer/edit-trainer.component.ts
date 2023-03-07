import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Trainer } from 'src/app/models/trainer.models';
import { TrainersService } from 'src/app/services/trainers.service';

@Component({
  selector: 'app-edit-trainer',
  templateUrl: './edit-trainer.component.html',
  styleUrls: ['./edit-trainer.component.css']
})
export class EditTrainerComponent implements OnInit{
  trainerDetails:Trainer={
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
  }
  constructor(private route:ActivatedRoute, private trainerService:TrainersService,private router:Router){}
  
  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next:(params)=>{
        const email=params.get('email');

        if(email){
          this.trainerService.getTrainerByEmail(email)
          .subscribe({
            next:(response)=>{
                this.trainerDetails=response;
            }
          })
        }
      }
    })
  }

  updateTrainer(){
    this.trainerService.updateTrainer(this.trainerDetails.email,this.trainerDetails)
    .subscribe({
      next:(response)=>{
        this.router.navigate(['/trainers']);
      }
    })
  }

}
