import React, { useState, FormEvent } from 'react';
import { Link } from 'react-router-dom';
import Button from '../atoms/Button';
import './Login.css';
import Input from '../atoms/Input';


function Login() {
  const [emailValue, setEmailValue] = useState('');
  const [passwordValue, setPasswordValue] = useState('');
  const [stayLoggedInValue, setStayLoggedInValue] = useState(false);

  const handleInputChange = (event: FormEvent<HTMLInputElement>): void => {
    const eventTarget: any = event.target;
    if (eventTarget.name === 'email') {
      setEmailValue(eventTarget.value);
    } else if (eventTarget.name === 'password') {
      setPasswordValue(eventTarget.value);
    } else {
      setStayLoggedInValue(eventTarget.checked);
    }
  };

  const login = () => {

  };

  return (
    <div className="login">
      <div className="login__form">
        <Input type="email">Email</Input>
        <Input type="password">Password</Input>
        <input type="checkbox" checked={stayLoggedInValue} onChange={handleInputChange} name="stayLoggedIn"/>
        <Button onClick={login}>Login</Button>
        <Link to={''}>Forgot password?</Link>
      </div>
    </div>
  );
}

export default Login;