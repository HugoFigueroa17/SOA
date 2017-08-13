<?php
    //para permitir el traspaso de información se manera segura
    if (isset($_SERVER['HTTP_ORIGIN'])) {
        header("Access-Control-Allow-Origin: {$_SERVER['HTTP_ORIGIN']}");
        header('Access-Control-Allow-Credentials: true');
        header('Access-Control-Max-Age: 86400'); // cache for 1 day
    }
    
    //Para establecer que trabajaremos por método POST
    if(strcasecmp($_SERVER['REQUEST_METHOD'], 'POST') != 0){
        throw new Exception('El método debería ser POST!');
    }
    
    //Establece que el formato de entrada será application/json
    $contentType = isset($_SERVER["CONTENT_TYPE"]) ? trim($_SERVER["CONTENT_TYPE"]) : '';
    if(strcasecmp($contentType, 'application/json') != 0){
        throw new Exception('Content type must be: application/json');
    }

    //Recibe el RAW 
    $content = trim(file_get_contents("php://input"));

    //transforma el RAW JSON a PHP
    $decoded = json_decode($content, true); //guarda la petición
    
    $message = array(); //para guardar la respuesta
    
    require 'config/Conexion.php';
    require 'api/apiTest.php';
    
    $miAPI = new Consultas();
    
 switch ($decoded['action']) {
    
    case "cUsuario":
        
        if(!isset($decoded['nombre'])
        ||!isset($decoded['correo'])
        ||!isset($decoded['direccion'])
        ||!isset($decoded['telefono'])
        ||!isset($decoded['tipo']))
        {
            $message["message"] = "Faltan parámetros";
        }
        else
        {
          if ($data = $miAPI->insertUsuario($decoded)) {
        		$message["message"] = "Informacion guardada";
          } else 
          {
               $message["message"] = "Error en la acción Insertar ";
          }   
        }
    
        break;
        
    case "rUsuario":
        if (is_array($data = $miAPI->selectUsuario())) 
        {
            $message = $data;
        } 
        else 
        {
            $message["message"] = "Error en la acción ";
        }        
        break;
    
    case "uUsuario":
        if(!isset($decoded['nombre'])
        ||!isset($decoded['correo'])
        ||!isset($decoded['direccion'])
        ||!isset($decoded['tel'])
        ||!isset($decoded['tipo'])
        ||!isset($decoded['id']))
        {
            $message["message"] = "Faltan parámetros";
        }
        else
        {
          if ($data = $miAPI->updateUsuario($decoded)) {
        		$message["message"] = "Informacion actualizada";
          } else 
          {
               $message["message"] = "Error en la acción ";
          }   
        }
    
        break;
        
    case "dUsuario":
        if(!isset($decoded['id']))
        {
            $message["message"] = "Faltan parámetros";
        }
        else
        {
          if ($data = $miAPI->deleteUsuario($decoded)) 
          {
        		$message["message"] = "Informacion eliminada";
          }
          else 
          {
               $message["message"] = "Error en la acción eliminar ";
          }   
        }
        break;
        
    case "cCliente":
        if(!isset($decoded['nombre'])
        ||!isset($decoded['telefono'])
        ||!isset($decoded['direccion'])
        ||!isset($decoded['email']))
        {
            $message["message"] = "Faltan parámetros";
        }
        else
        {
          if ($data = $miAPI->insertCliente($decoded)) {
        		$message["message"] = "Informacion guardada";
          } else 
          {
               $message["message"] = "Error en la acción Insertar ";
          }   
        }
        break;
    
    case "rCliente":
        if (is_array($data = $miAPI->selectCliente())) 
        {
            $message = $data;
        } 
        else 
        {
            $message["message"] = "Error en la acción ";
        }        
        break;
    
    case "rClienteXname":
        if(!isset($decoded['nombre']))
        {
            $message["message"] = "Faltan parámetros";
        }
        else
        {
            if (is_array($data = $miAPI->selectClienteN($decoded))) 
            {
                $message = $data;
            }
            else
            {
                $message["message"] = "Error en la acción ";
            }       
        }
        break;
      
        
    case "uCliente":
        if(!isset($decoded['nombre'])
        ||!isset($decoded['telefono'])
        ||!isset($decoded['direccion'])
        ||!isset($decoded['email'])
        ||!isset($decoded['id']))
        {
            $message["message"] = "Faltan parámetros";
        }
        else
        {
          if ($data = $miAPI->updateCliente($decoded)) {
        		$message["message"] = "Informacion actualizada";
          } else 
          {
               $message["message"] = "Error en la acción Insertar ";
          }   
        }
        break;
        
    case "dCliente":
        if(!isset($decoded['nombre']))
        {
            $message["message"] = "Faltan parámetros";
        }
        else
        {
          if ($data = $miAPI->deleteCliente($decoded)) 
          {
        		$message["message"] = "Informacion eliminada";
          }
          else 
          {
               $message["message"] = "Error en la acción eliminar ";
          }   
        }
    
        break;
    case "dAllClientes":
        if ($data = $miAPI->dCliente()) 
        {
            $message["message"] = "Se eliminó la información";
        } 
        else 
        {
            $message["message"] = "Error en la acción ";
        }       
        break;
        
    case "cAdministrador":
        if(!isset($decoded['user'])
        ||!isset($decoded['password'])
        ||!isset($decoded['nombre']))
        {
            $message["message"] = "Faltan parámetros";
        }
        else
        {
          if ($data = $miAPI->insertAdministrador($decoded)) {
        		$message["message"] = "Informacion guardada";
          } else 
          {
               $message["message"] = "Error en la acción Insertar ";
          }   
        }
        break;
        
    case "rAdministrador":
    
       
            if (is_array($data = $miAPI->selectAdministrador())) 
            {
                $message = $data;
            } 
            else 
            {
                $message["message"] = "Error en la acción ";
            }    
            
        break;
    
    
    case "uAdministrador":
        if(!isset($decoded['user'])
        ||!isset($decoded['pw'])
        ||!isset($decoded['nombre'])
        ||!isset($decoded['id']))
        {
            $message["message"] = "Faltan parámetros";
        }
        else
        {
          if ($data = $miAPI->updateAdministrador($decoded)) 
          {
        		$message["message"] = "Informacion actualizada";
          } else 
          {
               $message["message"] = "Error en la acción actualizar ";
          }   
        }
        break;
        
    case "dAdministrador":
        if(!isset($decoded['id']))
        {
            $message["message"] = "Faltan parámetros";
        }
        else
        {
          if ($data = $miAPI->deleteAdministrador($decoded)) 
          {
        		$message["message"] = "Informacion eliminada";
          }
          else 
          {
               $message["message"] = "Error en la acción eliminar ";
          }   
        }
        break;
        
      case "cPedido":
        if(!isset($decoded['producto'])
        ||!isset($decoded['descripcion'])
        ||!isset($decoded['fechaI'])
        ||!isset($decoded['fechaE'])
        ||!isset($decoded['inicio'])
        ||!isset($decoded['destino'])
        ||!isset($decoded['idUsuario'])
        ||!isset($decoded['idCliente']))
        {
          $message["message"] = "Faltan parámetros";
        }
        else
        {
          if ($data = $miAPI->insertPedido($decoded)) 
          {
            $message["message"] = "Pedido realizado correctamente";
          } else 
          {
               $message["message"] = "Error al realizar pedido";
          }
        }
       
        break;
        
    case "rPedido":
        if (is_array($data = $miAPI->leerpedidos())) 
        {
            $message = $data;
        } 
        else 
        {
            $message["message"] = "Error en la acción ";
        }        
        break;

    case "cMovimiento":
        if(!isset($decoded['fecha'])
        ||!isset($decoded['observaciones'])
        ||!isset($decoded['idPedido'])
        ||!isset($decoded['status'])
        ||!isset($decoded['lug_Actual']))
        {
          $message["message"] = "Faltan parámetros";
        }
        else
        {
          if ($data = $miAPI->insertMovimiento($decoded)) 
          {
            $message["message"] = "Movimiento realizado correctamente";
          } else 
          {
               $message["message"] = "Error al realizar movimiento";
          }
        }

        break;

    case "rMovimiento":
        if(!isset ($decoded['codigo']))
        {
            $message["message"] = "Faltan parámetros";
        }
        else
        {
            if (is_array($data = $miAPI->selectMovimientos($decoded))) 
            {
                $message = $data;
            } 
            else 
            {
                $message["message"] = "Error en la acción ";
            }    
        } 
        break;
        
    case "tMovimientos":
        if (is_array($data = $miAPI->todoMovi())) 
        {
            $message = $data;
        } 
        else 
        {
            $message["message"] = "Error en la acción ";
        }        
        break;
    case "rPassword":
        if(!isset($decoded['nombre']))
        {
            $message['message'] = "Faltan parametros";
        }
        else
        {
            if (is_array($data = $miAPI->rPw($decoded))) 
            {
                $message = $data;
            } 
            else 
            {
                $message["message"] = "Error en la acción ";
            }   
        }
        break;
    
    default:
         $message["message"] = "Accion NO valida";
        break;
}

//Codificar a JSON y mostrarlo en pantalla
header('Content-type: application/json; charset=utf-8');
$miJSON = json_encode($message, JSON_UNESCAPED_UNICODE | JSON_PRETTY_PRINT);
print $miJSON;