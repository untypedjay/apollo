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
      <p className="list-item__text">{ children }</p>
      <Button onClick={() => editAction(children)} buttonType="transparent"><FaEdit/></Button>
      <Button onClick={() => deleteAction(children)} buttonType="transparent"><FaTrashAlt/></Button>
    </div>
  );
}

export default ListItem;