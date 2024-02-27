﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Schneegans.Unattend;

public static class Extensions
{
  public static XmlNode SelectSingleNodeOrThrow(this XmlNode node, string xpath, XmlNamespaceManager nsmgr)
  {
    return node.SelectSingleNode(xpath, nsmgr) ?? throw new NullReferenceException($"No node matches XPath '{xpath}'.");
  }

  public static XmlNode SelectSingleNodeOrThrow(this XmlNode node, string xpath)
  {
    return node.SelectSingleNode(xpath) ?? throw new NullReferenceException($"No node matches XPath '{xpath}'.");
  }

  public static IEnumerable<XmlNode> SelectNodesOrEmpty(this XmlNode node, string xpath)
  {
    XmlNodeList? result = node.SelectNodes(xpath);
    return result == null ? [] : result.Cast<XmlNode>();
  }

  public static IEnumerable<XmlNode> SelectNodesOrEmpty(this XmlNode node, string xpath, XmlNamespaceManager nsmgr)
  {
    XmlNodeList? result = node.SelectNodes(xpath, nsmgr);
    return result == null ? [] : result.Cast<XmlNode>();
  }

  public static void RemoveSelf(this XmlNode node)
  {
    node.ParentNode.RemoveChild(node);
  }
}