import React, { DetailedHTMLProps, InputHTMLAttributes } from 'react';
import './Input.css';

interface Props extends DetailedHTMLProps<InputHTMLAttributes<HTMLInputElement>, HTMLInputElement>{
  type: string,
  children: string
}

function Input({ type = 'text', value, name, onChange, children }: Props) {
  return (
    <div className="input">
      <input className="input__input" type={type} value={value} name={name} onChange={onChange} placeholder={children}/>
      <div className="input__placeholder">
        { children }
      </div>
    </div>
  );
}

export default Input;