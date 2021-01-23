import React from 'react';
import { FaEdit, FaTrashAlt } from 'react-icons/fa';
import Button from '../atoms/Button';
import './ListItem.css';

interface Props {
  editAction: (item: any) => void;
  deleteAction: (item: any) => void;
  children: string;
}

function ListItem({ editAction, deleteAction, children }: Props) {
  return (
    <div className="list-item">
      <div className="list-item__text-container">
        <p className="list-item__text">{ children }</p>
      </div>
      <div className="list-item__button-container">
        <Button onClick={() => editAction(children)} buttonType="transparent">
          <FaEdit className="list-item__icon--white"/>
        </Button>
        <Button onClick={() => deleteAction(children)} buttonType="transparent">
          <FaTrashAlt className="list-item__icon--red"/>
        </Button>
      </div>
    </div>
  );
}

export default ListItem;