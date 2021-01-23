import React from 'react';
import './List.css';
import ListItem from '../molecules/ListItem';

interface Props {
  title: string;
  data: any[];
  property: string;
  editAction: (item: any) => void;
  deleteAction: (item: any) => void;
}

function List({ title, data, property, editAction, deleteAction }: Props) {
  return (
    <div className="list">
      <h3>{ title }</h3>
      <div className="list__container">
        { data.map(item => <ListItem key={item[property]} editAction={editAction} deleteAction={deleteAction}>{ item[property] }</ListItem>)}
      </div>
    </div>
  );
}

export default List;