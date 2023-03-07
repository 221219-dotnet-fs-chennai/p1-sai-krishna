import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Trainer } from '../models/trainer.models';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class TrainersService {
  baseApiUrl:string=environment.baseApiUrl; 
  constructor(private  https:HttpClient) {}
  getAllTrainers():Observable<Trainer[]>
  {
     return this.https.get<Trainer[]>(this.baseApiUrl+'/api/Admin/GetAllTrainers'); 
  }
  addTrainer(addTrainerReq:Trainer):Observable<Trainer[]>
  
  {
    return this.https.post<Trainer[]>(this.baseApiUrl+'/api/Trainer/signUp',addTrainerReq); 
  }
  getTrainerByEmail(email:string):Observable<Trainer>
  {
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'responseType': 'json',
      'email':email
  });
    return this.https.get<Trainer>(this.baseApiUrl+'/api/Trainer/getTrainerDetails' , { headers: headers });
  }

  updateTrainer(email:string,uptrainer:Trainer):Observable<Trainer>
  {
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'responseType': 'json',
      'email':email
  });
    return this.https.put<Trainer>(this.baseApiUrl+'/api/Trainer/UpdateTrainer' ,uptrainer, { headers: headers });
  }


  deleteTrainerByEmail(email:string):Observable<Trainer>
  {
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'responseType': 'json',
      'email':email
  });
    return this.https.delete  <Trainer>(this.baseApiUrl+'/api/Trainer/DeleteAccount' , { headers: headers });
  }

}
 