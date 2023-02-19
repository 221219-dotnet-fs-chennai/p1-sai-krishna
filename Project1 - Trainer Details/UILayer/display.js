
function displayAllTrainers(){
fetch('https://localhost:7040/api/Admin/GetAllTrainers')
    .then(res =>{
        if(!res.ok){
            console.log("error");
            return; 
        }
       return res.json();
    })
        .then(data=>{
            data.forEach(trainer => {
               //console.log(trainer.name);
               const markup=`<div class="card"id="dis"><div class="card-body row g-3" ><div class="col-md-4" >
               Name:${trainer.name}
           </div>
           <div class="col-md-4">
               Email:${trainer.email}
           </div>
           <div class="col-md-4">
               gender:${trainer.gender}
           </div>
           <div class="col-md-4">
               City:${trainer.city}
           </div><div class="col-md-4">
               State:${trainer.state}
           </div>
           <div class="col-md-4">
               Pincode:${trainer.pincode}
           </div><div></div>`;
               document.querySelector('.divp').insertAdjacentHTML('beforeend', markup)
            });
        }).catch(error=>{
            alert(error);
        })
}
function displayByGender(){
    var gendata=document.querySelector(".gender");
    console.log(gendata.value);
    fetch('https://localhost:7040/api/Admin/GetTrainersByGender?gender='+gendata.value)
        .then(res =>{
            if(!res.ok){
                console.log("error");
                return; 
            }
           return res.json();
        })
            .then(data=>{
                data.forEach(trainer => {
                   //console.log(trainer.name);
                   const markup=`<div class="card"id="dis"><div class="card-body row g-3" ><div class="col-md-4" >
                   Name:${trainer.name}
               </div>
               <div class="col-md-4">
                   Email:${trainer.email}
               </div>
               <div class="col-md-4">
                   gender:${trainer.gender}
               </div>
               <div class="col-md-4">
                   City:${trainer.city}
               </div><div class="col-md-4">
                   State:${trainer.state}
               </div>
               <div class="col-md-4">
                   Pincode:${trainer.pincode}
               </div><div></div>`;
                   document.querySelector('.divGender').insertAdjacentHTML('beforeend', markup)
                });
            }).catch(error=>{
                alert(error);
            })
}

function displayByCity()
    {
        var citydata=document.querySelector("#inputCity");
        console.log(citydata.value);
        fetch('https://localhost:7040/api/Admin/GetTrainersByCity?city='+citydata.value)
        .then(res =>{
            if(!res.ok){
                
                return; 
            }
           return res.json();
        })
            .then(data=>{
                data.forEach(trainer => {
                   //console.log(trainer.name);
                   const markup=`<div class="card"id="dis"><div class="card-body row g-3" ><div class="col-md-4" >
                   Name:${trainer.name}
               </div>
               <div class="col-md-4">
                   Email:${trainer.email}
               </div>
               <div class="col-md-4">
                   gender:${trainer.gender}
               </div>
               <div class="col-md-4">
                   City:${trainer.city}
               </div><div class="col-md-4">
                   State:${trainer.state}
               </div>
               <div class="col-md-4">
                   Pincode:${trainer.pincode}
               </div><div></div>`;
                   document.querySelector('.divCity').insertAdjacentHTML('beforeend', markup)
                });
            }).catch(error=>{
                alert("No trainers found");
            })
}
function displayByPincode()
{
    var pindata=document.querySelector("#inputPincode");
        console.log(pindata.value);
        fetch('https://localhost:7040/api/Admin/GetTrainersByPincode?Pincode='+pindata.value)
        .then(res =>{
            if(!res.ok){
                
                return; 
            }
           return res.json();
        })
            .then(data=>{
                data.forEach(trainer => {
                   //console.log(trainer.name);
                   const markup=`<div class="card"id="dis"><div class="card-body row g-3" ><div class="col-md-4" >
                   Name:${trainer.name}
               </div>
               <div class="col-md-4">
                   Email:${trainer.email}
               </div>
               <div class="col-md-4">
                   gender:${trainer.gender}
               </div>
               <div class="col-md-4">
                   City:${trainer.city}
               </div><div class="col-md-4">
                   State:${trainer.state}
               </div>
               <div class="col-md-4">
                   Pincode:${trainer.pincode}
               </div><div></div>`;
                   document.querySelector('.divPincode').insertAdjacentHTML('beforeend', markup)
                });
            }).catch(error=>{
                alert("No trainers found");
            })
}   
function displayBySkill()
{
    var skilldata=document.querySelector("#inputSkill");
    console.log(skilldata.value);
    fetch('https://localhost:7040/api/Admin/GetTrainersBySkill?skill='+skilldata.value)
    .then(res =>{
        if(!res.ok){
            
            return; 
        }
       return res.json();
    })
        .then(data=>{
            data.forEach(trainer => {
               //console.log(trainer.name);
               const markup=`<div class="card"id="dis"><div class="card-body row g-3" ><div class="col-md-4" >
               Name:${trainer.name}
           </div>
           <div class="col-md-4">
               Email:${trainer.email}
           </div>
           <div class="col-md-4">
               gender:${trainer.gender}
           </div>
           <div class="col-md-4">
               City:${trainer.city}
           </div><div class="col-md-4">
               State:${trainer.state}
           </div>
           <div class="col-md-4">
               Pincode:${trainer.pincode}
           </div><div></div>`;
               document.querySelector('.divSkill').insertAdjacentHTML('beforeend', markup)
            });
        }).catch(error=>{
            alert("No trainers found");
        })
}
//------------------------------------------------------------------------------------------------------------------------------------------------------  
    function signIn()
    {
        const signInForm1= document.getElementById("signInForm");

        signInForm1.addEventListener('submit',event => {
            event.preventDefault();    });
           
            const formData=new FormData(signInForm1);
            const data=Object.fromEntries(formData);
            var email1=formData.get('emailsi');
            localStorage.setItem("myEmail", email1);
            fetch('https://localhost:7040/api/Trainer/signIn',{
                method:'GET',
                headers:{
                    'email':formData.get('emailsi'),
                    'password':formData.get('passwordsi')
                }
            }).then(res=> {
                
                    res.text().then(function (text){
                        if(text=="Successful login"){
                            alert("Login Successful ");
                            window.location.replace('userOperations.html');
                           
                        }
                        else if(text=="Wrong password"){
                            alert(text);
                        }
                        else if(text=="Email does not exists,please sign up"){
                            alert(text);
                        }
                        else{
                            alert("Please try again")
                        }
                    });
                        
                
            });
    }  
    function signUp()
    {
        const signUpForm1= document.getElementById("signUpForm");

        signUpForm1.addEventListener('submit',event => {
            event.preventDefault(); });

        const formData=new FormData(signUpForm1);
        const data=Object.fromEntries(formData);
        fetch('https://localhost:7040/api/Trainer/signUp',{
            method:'POST',
            headers:{
                'Content-Type':'application/json',

            },
            body:JSON.stringify(data)
        }).then(res=>{
            if(res.ok){
                console.log(JSON.stringify(data));
                alert("Sign Up successful, Please Sign In");
                window.location.replace("signIn.html");
            }
            else{
                res.text().then(function (text){
                    alert(text);
                })
            }
        }).catch(error=>{
            alert("errooe");
        });
    }
//-------------------------------------------------------Personel Details----------------------------------------------------------------------------------------------
    function getPersonalDetails()
    {
        var email = localStorage.getItem("myEmail");
            fetch('https://localhost:7040/api/Trainer/getTrainerDetails',{
                method:'GET',
                headers:{
                    'email':email
                }
            }).then(res=>{
                if(res.ok){
                    return res.json();
                }
            }).then(data=>{
                //console.log(typeof(data));
                var tdat=JSON.stringify(data);
                const markup=`<div class="card"id="dis"><div class="card-body row g-6" >
            <div class="p-2 col-md-4 " >
               <b>Name:</b> ${data.name}
           </div>
           <div class="p-2 col-md-4">
           <b>Email:</b> ${data.email}
           </div>
          
           <div class=" p-2 col-md-4">
           <b> gender:</b>${data.gender}
           </div>

           <div class="p-2 col-md-4">
           <b> Phone: </b>${data.phoneNo}
           </div>
           
           <div class="p-2 col-md-8">
           <b> Address:</b> ${data.city},${data.state}-${data.pincode}
           </div>
           <div class="p-2 col-md-12">
           <b> About Me:</b> ${data.aboutMe}
           </div>
           <div class="p-2 col-md-3 "></div>
            <div class="p-2 col-md-2">
           <button type="button" class="btn btn-dark " value='${tdat}' onclick="trainerUpdateForm(value)">Update</button>
           </div>
           <div class="p-2 col-md-2">
           <button type="button" class="btn btn-danger " id="deleteAccount" onclick="deleteAccount()">Delete</button>
           </div><div></div>`;
               document.querySelector('.divp').insertAdjacentHTML('beforeend', markup)
            });
    }
    function trainerUpdateForm(details){
            perDetails=JSON.parse(details);
            console.log(perDetails);
            const markup=
            `<div class="form-popup" id="myFormDet">
            <form action="" class="form-container" id="updateDet">
            <input type="text" value="${perDetails.email}" name="email" readonly>
              <label ><b> Name</b></label>
              <input type="text" value="${perDetails.name}" name="name">

              <label ><b> Password</b></label>
              <input type="password" value="${perDetails.password}" name="password">
        
              <label><b>Gender</b></label>
              <select name="gender">
                <option selected>${perDetails.gender} </option> 
                <option value="M">M</option>
                <option value="F">F</option>
              </select>
        
              <br><label ><b>Phone Number</b></label>
              <input type="text" value="${perDetails.phoneNo}" placeholder="Enter Your Phone Number" name="phoneNo">
        
              <label ><b>City</b></label>
              <input type="text" value="${perDetails.city}" placeholder="Enter City" name="city" >
        
              <label ><b>State</b></label>
              <select name="state">
                <option selected >${perDetails.state}</option>
                <option value="Andhra Pradesh">Andhra Pradesh</option>
                <option value="Goa">Goa</option>
                <option value="Karnataka">Karnataka</option>
                <option value="Kerla">Kerla</option>
                <option value="Maharashtra">Maharashtra</option>
                <option value="Tamil Nadu">Tamil Nadu</option>
                <option value="Telangana">Telangana</option>
              </select>
        
              <br><label ><b>Pincode</b></label>
              <input type="text" value="${perDetails.pincode}" placeholder="Enter Pincode" name="pincode" >

              <label ><b>Something About You<b></label>
              <input type="text" value="${perDetails.aboutMe} "name="aboutMe">
        
              <button type="submit" class="btn " onclick="updatePer()">Update</button>
              <button type="button" class="btn cancel" onclick="closeFormDet()">Close</button>
            </form>
          </div> `;
            document.querySelector('#formshow').insertAdjacentHTML('afterend', markup);
           
            openFormDet();
            
    }
    function updatePer()
    {
        const updatedetails= document.getElementById("updateDet");

        updatedetails.addEventListener('submit',event => {
            event.preventDefault(); });

        const formData=new FormData(updatedetails);
        const data=Object.fromEntries(formData);
        fetch('https://localhost:7040/api/Trainer/UpdateTrainer',{
            method:'PUT',
            headers:{
                'Content-Type':'application/json',
                'email':localStorage.getItem("myEmail")
            },
            body:JSON.stringify(data)
        }).then(res=>{
            if(res.ok){
                console.log(JSON.stringify(data));
                alert("Updated Succesfully");
                window.location.replace("userOperations.html");
            }
            else{
                res.text().then(function (text){
                    alert(text);
                })
            }
        }).catch(error=>{
            alert("error");
        });
    }
    function deleteAccount()
    {
        const account= document.getElementById("deleteAccount");
        var email = localStorage.getItem("myEmail");
        account.addEventListener('submit',event => {
            event.preventDefault(); });

            if(confirm("Are you sure you want to delete your account??")){
            fetch('https://localhost:7040/api/Trainer/DeleteAccount',{
                method:'DELETE',
                headers:{
                    'Content-Type':'application/json',
                    'email':email,
                }
            }).then(res=>{
                if(res.ok){
                    alert("Account Deleted, Thank You for your service");
                    window.location.replace('index.html');
                }
                else{
                    res.text().then(function (text){
                        alert(text);
                    })
                }
            }).catch(error=>{
                alert("error");
            });}
            else{
                window.location.replace('userOperations.html');
            }
    }
 //----------------------------------------------------------Achivements--------------------------------------------------------------------------------------------   
    function getAchivements()
    {
        var email = localStorage.getItem("myEmail");
            fetch('https://localhost:7040/api/Achivements/DisplayAchivements',{
                method:'GET',
                headers:{
                    'email':email
                }
            }).then(res=>{
                if(res.ok){
                    return res.json();
                }
            }).then(data=>{data.forEach(achivements=>{
                var adat=JSON.stringify(achivements);
                const markup=`<div class="card"id="dis"><div class="card-body row g-3" >
            <div class="col-md-9" >
            <b>${achivements.title}:</b>
           </div>
           <div class="col-md-1">
           <button type="button" class="btn btn-dark btn-sm" value='${adat}' onclick="achUpdateForm(value)">Update</button>
           </div>
           <div class="col-md-2">
           <button type="button" class="btn btn-danger btn-sm" id="deleteAchivement" value="${achivements.title}" onclick="deleteAchivemnet(value)">Delete</button>
           </div>
           <div class="col-md-12">
            ${achivements.description}
           </div>`;
           document.querySelector('.divAch').insertAdjacentHTML('beforeend', markup);
            });
               
            });
    }
    function addAchivement(){
        const achivements= document.getElementById("addAch");
        var email = localStorage.getItem("myEmail");
        achivements.addEventListener('submit',event => {
            event.preventDefault(); });

        const achData=new FormData(achivements);
        const data=Object.fromEntries(achData);
        fetch('https://localhost:7040/api/Achivements/InsertAchivement',{
            method:'POST',
            headers:{
                'Content-Type':'application/json',
                'email':email
            },
            body:JSON.stringify(data)
        }).then(res=>{
            if(res.ok){
                alert("Achivement Added");
                window.location.replace('userOperations.html');
            }
            else{
                res.text().then(function (text){
                    alert(text);
                })
            }
        }).catch(error=>{
            alert("error");
        });
    }
    function achUpdateForm(Achivements)
    {
        achData=JSON.parse(Achivements);
        console.log(achData);
        const markup=
            `<div class="form-popup" id="myFormAchu">
            <form action="" class="form-container" id="updateAch">
        
            <label ><b>Title</b></label>
            <input type="text" value="${achData.title}"placeholder="Enter Title" name="title" required>
        
            <label ><b>Description</b></label>
            <input type="text" value="${achData.description}" placeholder="Enter Description" name="description" required>
        
            <button type="submit" class="btn" onclick="updateAchivement()">Update</button>
            <button type="button" class="btn cancel" onclick="closeFormAchu()">Close</button>
            </form>
        </div>  `;
        document.querySelector('#myFormAch').insertAdjacentHTML('afterend', markup);
        localStorage.setItem("AchNametoU",achData.title);
        openFormAchu();
    }
    function updateAchivement()
    {
       
        const achivements= document.getElementById("updateAch");
        var email = localStorage.getItem("myEmail");
        achivements.addEventListener('submit',event => {
            event.preventDefault(); });

        const achData=new FormData(achivements);
        const data=Object.fromEntries(achData);
        fetch('https://localhost:7040/api/Achivements/UpdateAchivement',{
            method:'PUT',
            headers:{
                'Content-Type':'application/json',
                'email':email,
                'achivementName':localStorage.getItem("AchNametoU")
            },
            body:JSON.stringify(data)
        }).then(res=>{
            if(res.ok){
                alert("Achivement/Certificate Updated");
                window.location.replace('userOperations.html');
            }
            else{
                res.text().then(function (text){
                    alert(text);
                })
            }
        }).catch(error=>{
            alert("errooe");
        });
    }
    function deleteAchivemnet(achName)
    {
        const achivement= document.getElementById("deleteAchivement");
        var email = localStorage.getItem("myEmail");
        achivement.addEventListener('submit',event => {
            event.preventDefault(); });

            fetch('https://localhost:7040/api/Achivements/DeleteAchivement',{
                method:'DELETE',
                headers:{
                    'Content-Type':'application/json',
                    'email':email,
                    'achivementName':achName
                }
            }).then(res=>{
                if(res.ok){
                    alert("Achivement Deleted");
                    window.location.replace('userOperations.html');
                }
                else{
                    res.text().then(function (text){
                        alert(text);
                    })
                }
            }).catch(error=>{
                alert("error");
            });
    }
//--------------------------------------------------------------Education-------------------------------------------------------------------------------------------------
    function getEducation()
    {
        var email = localStorage.getItem("myEmail");
            fetch('https://localhost:7040/api/Education/DisplayEducations',{
                method:'GET',
                headers:{
                    'email':email
                }
            }).then(res=>{
                if(res.ok){
                    return res.json();
                }
            }).then(data=>{data.forEach(edu=>{
                var edudat=JSON.stringify(edu);
                const markup=`<div class="card"id="dis"><div class="card-body row g-3" >
            <div class="col-md-6" >
            <b>Institute Name:</b>${edu.instituteName}
           </div>
           <div class="col-md-6">
           <b>Degree:</b>${edu.degree}
           </div>
           <div class="col-md-6">
           <b>Start Date:</b>${edu.startDate}
           </div>
           <div class="col-md-4">
           <b>End Date:</b>${edu.endDate}
           </div>
           <div class="col-md-4">
           <b>Score:</b> ${edu.score}
           </div>
           <div class="col-md-6"></div>
           <div class="col-md-4"></div>

           <div class="col-md-1">
           <button type="button" class="btn btn-dark btn-sm" value='${edudat}' onclick="EduUpdateForm(value)">Update</button>
           </div>
           <div class="col-md-2">
           <button type="button" class="btn btn-danger btn-sm" id="deleteEdu" value="${edu.instituteName}" onclick="deleteEducation(value)">Delete</button>
           </div>
           `;
           document.querySelector('.divEdu').insertAdjacentHTML('beforeend', markup);
            });
               
            });
    }
    function addEducation()
    {
        const education= document.getElementById("addEdu");
        var email = localStorage.getItem("myEmail");
        education.addEventListener('submit',event => {
            event.preventDefault(); });

        const eduData=new FormData(education);
        const data=Object.fromEntries(eduData);
        fetch('https://localhost:7040/api/Education/InsertEducation',{
            method:'POST',
            headers:{
                'Content-Type':'application/json',
                'email':email
            },
            body:JSON.stringify(data)
        }).then(res=>{
            if(res.ok){
                alert("Education Added");
                window.location.replace('userOperations.html');
            }
            else{
                res.text().then(function (text){
                    alert(text);
                })
            }
        }).catch(error=>{
            alert("error");
        });
    }
    function EduUpdateForm(education){
        eduData=JSON.parse(education);
        console.log(eduData);
        const markup=
        `<div class="form-popup" id="myFormEduu">
        <form action="" class="form-container" id="updateEdu">
  
          <label ><b>Institute Name</b></label>
          <input type="text" value="${eduData.instituteName}" placeholder="Enter Institute Name" name="instituteName">
  
          <label ><b>Degree</b></label>
          <input type="text" value="${eduData.degree}" placeholder="Enter Degree" name="degree">
  
          <label ><b>Start Date</b></label>
          <input type="text" value="${eduData.startDate}"placeholder="Enter Start Date(MM/YYYY)" name="startDate">
  
          <label ><b>End Date</b></label>
          <input type="text" value="${eduData.endDate}" placeholder="Enter End Date(MM/YYYY or 'Present')" name="endDate">
  
          <label ><b>Score</b></label>
          <input type="text" value="${eduData.score}" placeholder="Enter Score" name="score">
  
  
          <button type="submit" class="btn" onclick="updateEducation()">Update</button>
          <button type="button" class="btn cancel" onclick="closeFormEduu()">Close</button>
        </form></div> `;
        document.querySelector('#myFormEdu').insertAdjacentHTML('afterend',markup);
        localStorage.setItem("EduToU",eduData.instituteName);
        openFormEduu();
    }
    function updateEducation(){
        const educations= document.getElementById("updateEdu");
        var email = localStorage.getItem("myEmail");
        educations.addEventListener('submit',event => {
            event.preventDefault(); });

        const eduData=new FormData(educations);
        const data=Object.fromEntries(eduData);
        fetch('https://localhost:7040/api/Education/UpdateEducation',{
            method:'PUT',
            headers:{
                'Content-Type':'application/json',
                'email':email,
                'InstituteName':localStorage.getItem("EduToU")
            },
            body:JSON.stringify(data)
        }).then(res=>{
            if(res.ok){
                alert("Education Updated");
                window.location.replace('userOperations.html');
            }
            else{
                res.text().then(function (text){
                    alert(text);
                })
            }
        }).catch(error=>{
            alert("error");
        });
    }
    function deleteEducation(instiName)
    {
        const education= document.getElementById("deleteEdu");
        var email = localStorage.getItem("myEmail");
        education.addEventListener('submit',event => {
            event.preventDefault(); });

            fetch('https://localhost:7040/api/Education/DeleteEducation',{
                method:'DELETE',
                headers:{
                    'Content-Type':'application/json',
                    'email':email,
                    'InstituteName':instiName
                }
            }).then(res=>{
                if(res.ok){
                    alert("Education Deleted");
                    window.location.replace('userOperations.html');
                }
                else{
                    res.text().then(function (text){
                        alert(text);
                    })
                }
            }).catch(error=>{
                alert("error");
            });
    }
//------------------------------------------------------------------------------------------------------------------------------------------------------------------
    function getExperience()
    {
        var email = localStorage.getItem("myEmail");
            fetch('https://localhost:7040/api/Experience/DisplayExperience',{
                method:'GET',
                headers:{
                    'email':email
                }
            }).then(res=>{
                if(res.ok){
                    return res.json();
                }
            }).then(data=>{data.forEach(ex=>{
                var exdat=JSON.stringify(ex);
                const markup=`<div class="card"id="dis"><div class="card-body row g-3" >
            <div class="col-md-4" >
            <b>Company Name:</b> ${ex.companyName}
           </div>
           <div class="col-md-5">
           <b>Role:</b> ${ex.role}
           </div>
           <div class="col-md-1">
           <button type="button" class="btn btn-dark btn-sm" value='${exdat}' onclick="ExUpdateForm(value)">Update</button>
           </div>
           <div class="col-md-2">
           <button type="button" class="btn btn-danger btn-sm" value="${ex.companyName}" id="deleteEx" onclick="deleteExperience(value)">Delete</button>
           </div>
           <div class="col-md-4">
           <b>Start Date:</b> ${ex.startDate}
           </div>
           <div class="col-md-4">
           <b>End Date:</b> ${ex.endDate}
           </div>`;
           document.querySelector('.divEx').insertAdjacentHTML('beforeend', markup);
            });
               
            });
    }
    function addExperience(){
        const experience= document.getElementById("addEx");
        var email = localStorage.getItem("myEmail");
        experience.addEventListener('submit',event => {
            event.preventDefault(); });

        const exData=new FormData(experience);
        const data=Object.fromEntries(exData);
        fetch('https://localhost:7040/api/Experience/InsertExperience',{
            method:'POST',
            headers:{
                'Content-Type':'application/json',
                'email':email
            },
            body:JSON.stringify(data)
        }).then(res=>{
            if(res.ok){
                alert("Experience Added");
                window.location.replace('userOperations.html');
            }
            else{
                res.text().then(function (text){
                    alert(text);
                })
            }
        }).catch(error=>{
            alert("error");
        });
    }
    function ExUpdateForm(experience)
    {
        exData=JSON.parse(experience);
        console.log(exData);
        const markup=
        `<div class="form-popup" id="myFormExu">
        <form action="" class="form-container" id="updateEx">
    
          <label ><b>Company Name</b></label>
          <input type="text" value="${exData.companyName}"placeholder="Enter Company Name" name="companyName">
    
          <label ><b>Role</b></label>
          <input type="text" value="${exData.role}" placeholder="Enter Your Role" name="role">
    
          <label ><b>Start Date</b></label>
          <input type="text" value="${exData.startDate}" placeholder="Enter Start Date(MM/YYYY)" name="startDate">
    
          <label ><b>End Date</b></label>
          <input type="text" value="${exData.endDate}" placeholder="Enter End Date(MM/YYYY or 'Present')" name="endDate">
    
          <button type="submit" class="btn" onclick="updateExperience()">Update</button>
          <button type="button" class="btn cancel" onclick="closeFormExu()">Close</button>
        </form>
      </div>  `;
      document.querySelector('#myFormEx').insertAdjacentHTML('afterend',markup);
      localStorage.setItem("ExToU",exData.companyName);
      openFormExu();
    }
    function updateExperience()
    {
        const experiences= document.getElementById("updateEx");
        var email = localStorage.getItem("myEmail");
        experiences.addEventListener('submit',event => {
            event.preventDefault(); });

        const exData=new FormData(experiences);
        const data=Object.fromEntries(exData);
        fetch('https://localhost:7040/api/Experience/UpdateExperience',{
            method:'PUT',
            headers:{
                'Content-Type':'application/json',
                'email':email,
                'companyName':localStorage.getItem("ExToU")
            },
            body:JSON.stringify(data)
        }).then(res=>{
            if(res.ok){
                alert("Experience Updated");
                window.location.replace('userOperations.html');
            }
            else{
                res.text().then(function (text){
                    alert(text);
                })
            }
        }).catch(error=>{
            alert("error");
        });

    }
    function deleteExperience(cmpName)
    {
        const experience= document.getElementById("deleteEx");
        var email = localStorage.getItem("myEmail");
        experience.addEventListener('submit',event => {
            event.preventDefault(); });

            fetch('https://localhost:7040/api/Experience/DeleteExperience',{
                method:'DELETE',
                headers:{
                    'Content-Type':'application/json',
                    'email':email,
                    'companyName':cmpName
                }
            }).then(res=>{
                if(res.ok){
                    alert("Experience Deleted");
                    window.location.replace('userOperations.html');
                }
                else{
                    res.text().then(function (text){
                        alert(text);
                    })
                }
            }).catch(error=>{
                alert("error");
            });
    }
//----------------------------------------------------Skils---------------------------------------------------------------------------------------------
    function getSkills()
    {
        var email = localStorage.getItem("myEmail");
            fetch('https://localhost:7040/api/Skill/DisplaySkills',{
                method:'GET',
                headers:{
                    'email':email
                }
            }).then(res=>{
                if(res.ok){
                    return res.json();
                }
            }).then(data=>{data.forEach(skills=>{
                //console.log(skills.name);
                var sdat=JSON.stringify(skills);

                const markup=`<div class="card"id="dis"><div class="card-body row g-3" >
            <div class="col-md-5" >
            <b>  Name:</b> ${skills.name}
           </div>
           <div class="col-md-4">
           <b>  Description:</b> ${skills.description}
           </div>
          
           <div class="col-md-1">
           <button type="button" class="btn btn-dark btn-sm" value='${sdat}' onclick="skillUpdateForm(value)">Update</button>
           </div>
           <div class="col-md-2">
           <button type="button" class="btn btn-danger btn-sm" id="deleteSkill" value="${skills.name}" onclick="deleteSkill(value)">Delete</button>
           </div>`;
         
           document.querySelector('.divskill').insertAdjacentHTML('beforeend', markup);
            });
               
            });
        
            
            
    } 
   
    function addSkill(){
        const skills= document.getElementById("addSkill");
        var email = localStorage.getItem("myEmail");
        skills.addEventListener('submit',event => {
            event.preventDefault(); });

        const skillData=new FormData(skills);
        const data=Object.fromEntries(skillData);
        fetch('https://localhost:7040/api/Skill/InsertSkill',{
            method:'POST',
            headers:{
                'Content-Type':'application/json',
                'email':email
            },
            body:JSON.stringify(data)
        }).then(res=>{
            if(res.ok){
                alert("Skill Added");
                window.location.replace('userOperations.html');
            }
            else{
                res.text().then(function (text){
                    alert(text);
                })
            }
        }).catch(error=>{
            alert("error");
        });
    }

    function skillUpdateForm(skill){
        
        skilldata=JSON.parse(skill); 
        
        const markup=
        `<div class="form-popup" id="myFormu">
        <form action="" class="form-container" id="updateSkill">
      
          <label for="email"><b>Skill Name</b></label>
          <input type="text" placeholder="Enter Skill Name" value="${skilldata.name}" name="name" required>
      
          <label for="psw"><b>Description</b></label>
          <input type="text" placeholder="Enter Description" value="${skilldata.description}"name="description" required>
      
          <button type="submit" class="btn" onclick="updateSkill()">Update</button>
          <button type="button" class="btn cancel" onclick="closeFormuskill()">Close</button>
        </form>
      </div> `;
        document.querySelector('#myForm').insertAdjacentHTML('afterend', markup);
        localStorage.setItem("SkillNametoU",skilldata.name);
        openFormuskill();
    }

    function updateSkill(){
        const skills= document.getElementById("updateSkill");
        var email = localStorage.getItem("myEmail");
        skills.addEventListener('submit',event => {
            event.preventDefault(); });

        const skillData=new FormData(skills);
        const data=Object.fromEntries(skillData);
        fetch('https://localhost:7040/api/Skill/UpdateSkill',{
            method:'PUT',
            headers:{
                'Content-Type':'application/json',
                'email':email,
                'skillName':localStorage.getItem("SkillNametoU")
            },
            body:JSON.stringify(data)
        }).then(res=>{
            if(res.ok){
                alert("Skill Updated");
                window.location.replace('userOperations.html');
            }
            else{
                res.text().then(function (text){
                    alert(text);
                })
            }
        }).catch(error=>{
            alert("error");
        });
    }

    function deleteSkill(skillname){
        const skill= document.getElementById("deleteSkill");
        var email = localStorage.getItem("myEmail");
        skill.addEventListener('submit',event => {
            event.preventDefault(); });

            fetch('https://localhost:7040/api/Skill/DeleteSkill',{
                method:'DELETE',
                headers:{
                    'Content-Type':'application/json',
                    'email':email,
                    'skillName':skillname
                }
            }).then(res=>{
                if(res.ok){
                    alert("Skill Deleted");
                    window.location.replace('userOperations.html');
                }
                else{
                    res.text().then(function (text){
                        alert(text);
                    })
                }
            }).catch(error=>{
                alert("error");
            });
    }