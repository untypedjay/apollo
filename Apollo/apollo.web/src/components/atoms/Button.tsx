import React, { DetailedHTMLProps, ButtonHTMLAttributes } from 'react';
import './Button.css';

interface Props extends DetailedHTMLProps<ButtonHTMLAttributes<HTMLButtonElement>, HTMLButtonElement> {
  loading?: boolean,
  buttonType?: string
}

function Button({
  type = 'button',
  role = 'button',
  loading = false,
  buttonType = 'primary',
  disabled = false,
  tabIndex,
  onClick,
  children
}: Props) {
  return (
    <button
      role={role}
      disabled={loading ? true : disabled}
      className={`button button--${buttonType}`}
      type={type}
      tabIndex={disabled ? -1 : tabIndex}
      aria-busy={loading}
      onClick={onClick}
    >
      { children }
    </button>
  );
}

export default Button;