

import { useState } from "react";

import FormComponent from "../Component/FormComponent";
import InputComponent from "../Component/InputComponent";
import axios from "axios";


export default function RegisterPage(){
    const [name,setName] = useState("");
    const [gmail,setGmail] = useState("");
    const [username,setUsername] = useState("");
    const [password,setPassword] = useState("");
    const [phone,setPhone] = useState("");
    const [error,setError] = useState("");
    const [validationError, setValitionError] = useState({})

 
    const handleSubmit = async (e) => {
        e.preventDefault();
        setError("");
        setValitionError({});
        try{
        const res = await axios.post("http://localhost:5165/user/register",{
             Name: name,
                Username: username,
                Password: password,
                Email: gmail,   
                Phone: phone
        });
     setName(""); setUsername(""); setPassword(""); setGmail(""); setPhone("");
     
        alert(res.data);
    } catch (err){
        if (typeof err.response.data == "string") {
        setError(err.response.data);
    } else {
        console.log(err.response.data.errors);
        setValitionError(err.response.data.errors);
    }
    
    }
    
    }

    return (
        
     <>
     
 
    <FormComponent 
       title="Create Your Account" 
       subTitle="Join splitter community"
       optional="Already have an account? Sign in"
       linkTo="/login"
       >
         <form onSubmit={handleSubmit} >
              
            <InputComponent 
            labelText="Name"
            changeHandle={(e) => setName(e.target.value)}
            inputType="text"
            inputValue={name}
            placeholderValue="Enter your name"
            validationError={validationError.Name}
            />
            
            <InputComponent 
            labelText="Gmail"
            changeHandle={(e) => setGmail(e.target.value)}
            inputType="email"
            inputValue={gmail}
            validationError={validationError.Email}
            placeholderValue="Enter your gmail"
            />
            <InputComponent 
            labelText="Username"
            changeHandle={(e) => setUsername(e.target.value)}
            inputType="text"
            inputValue={username}
            placeholderValue="Enter your username"
            validationError={validationError.Username}
            />
            <InputComponent 
            labelText="Password"
            changeHandle={(e) => setPassword(e.target.value)}
            inputType="password"
            inputValue={password}
            placeholderValue="Enter your password"
            validationError={validationError.Password}
            />
            <InputComponent 
            labelText="Phone"
            changeHandle={(e) => setPhone(e.target.value)}
            inputType="text"
            inputValue={phone}
            placeholderValue="Enter your phone number"
            validationError={validationError.Phone}
            />
            <button type="submit" className="btn btn-warning w-100 mt-2">Register</button>
                    </form>
                    <p className="text-danger mt-3">{error !== "" ?  `*${error}` : ""}</p>
        </FormComponent>    

     </>   
    )
}