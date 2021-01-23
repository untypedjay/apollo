import React, { ReactNode } from 'react';
import { FaTimes } from 'react-icons/fa';
import Button from '../atoms/Button';
import './Modal.css';

interface Props {
  title: string;
  closeAction: () => void;
  children: ReactNode;
  secondaryAction: () => void;
  primaryAction: () => void;
};

function Modal({ title, closeAction, children, secondaryAction, primaryAction }: Props) {
  return (
    <div className="modal">
      <div className="modal__card">
        <h3 className="modal__title">{ title }</h3>
        <button className="modal__close-button" onClick={closeAction} title="Close">
          <FaTimes className="modal__icon" size="30px"/>
        </button>
        { children }
        <div className="modal__footer">
          <Button buttonType="secondary" onClick={secondaryAction}>Cancel</Button>
          <Button onClick={primaryAction}>OK</Button>
        </div>
      </div>
    </div>
  );
};

export default Modal;