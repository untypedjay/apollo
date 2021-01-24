import React, { DetailedHTMLProps, InputHTMLAttributes } from 'react';
import './Input.css';

interface Props extends DetailedHTMLProps<InputHTMLAttributes<any>, HTMLInputElement>{
  type?: string;
  children: string;
  optionList?: any[];
}

function Input({ type = 'text', value, name, onChange, children, optionList }: Props) {
  const renderSelectInput = () => {
    return (
      <select className="input__input" value={value} onChange={onChange}>
        { optionList && optionList.map(option => {
          return <option className="input__option" key={option} value={option}>{ option }</option>;
        })}
      </select>
    );
  };

  const renderGenericInput = () => {
    return (
      <input
        className="input__input"
        type={type}
        value={value}
        name={name}
        onChange={onChange}
        placeholder={children}
      />
    );
  }

  return (
    <div className="input">
      { (type === 'select') ? renderSelectInput() : renderGenericInput() }
      <div className="input__placeholder">
        { children }
      </div>
    </div>
  )
}

export default Input;