import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TrainersService } from 'src/app/services/trainers.service';

@Component({
  selector: 'app-delete-trainer',
  template: `<p>hello</p>`,
  styleUrls: ['./delete-trainer.component.css']
})
export class DeleteTrainerComponent implements OnInit {
  constructor(private route:ActivatedRoute, private trainerService:TrainersService,private router:Router){}
  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next:(params)=>{
        const email=params.get('email');

        if(email){
          this.trainerService.deleteTrainerByEmail(email)
          .subscribe({
            next:(response)=>{
                window.alert("Account Deleted");
                this.router.navigate(['trainers']);
            }
          })
        }
      }
    })
  }
 
}
