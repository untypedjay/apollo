import React, { useState, FormEvent } from 'react';
import { Link, useHistory } from 'react-router-dom';
import Input from '../atoms/Input';
import Button from '../atoms/Button';
import ApolloLogo from '../../images/apollo-logo.png';
import './Login.css';

function Login() {
  const [emailValue, setEmailValue] = useState('');
  const [passwordValue, setPasswordValue] = useState('');
  const [stayLoggedInValue, setStayLoggedInValue] = useState(false);
  const history = useHistory();

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
    if (emailValue === 'admin' && passwordValue === 'admin') {
      history.push('/admin');
    } else {
      alert('Email or password incorrect!');
    }
  };

  return (
    <div className="login">
      <div className="login__container">
        <Link to="/"><img className="login__branding" src={ApolloLogo} alt="Apollo Logo"/></Link>
        <h3 className="login__heading">Login</h3>
        <div className="login__form">
          <Input type="email" value={emailValue} name="email" onChange={handleInputChange}>Email</Input>
          <Input type="password" value={passwordValue} name="password" onChange={handleInputChange}>Password</Input>
          <input type="checkbox" checked={stayLoggedInValue} onChange={handleInputChange} name="stayLoggedIn"/>
          <Button onClick={login}>Login</Button>
          <Link to={''}>Forgot password?</Link>
        </div>
      </div>
    </div>
  );
}

export default Login;